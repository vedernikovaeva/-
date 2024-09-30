using System;
using System.Collections.Generic;
using System.Linq;
using static Program;
//завдання 1, варіант 2
//Елементи колекції «бібліотека» мають наступну структуру: код книги, назва, автор, рік видання.
//У колекції «Читачі» зберігаються прізвища читачів, коди виданих читачам книг, дати видачі, дати повернення.
//a) Вивести назв книг заданого автора, що були видані протягом вказаного діапазону дат.
//b) Підрахувати загальну кількість книг неповернутих читачами книг, які були видані
//у минулому столітті та вибрані у поточному році.
//c) Вивести перелік з N найбільш «популярних» книг,
//виданих у поточному році(книг, які видавалися читачам найбільш часто), де N — задане число
class Program
{
    public class Books
    {

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    public class Readers
    {
        public string LastName { get; set; }
        public int BookId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }


    static void Main()
    {
        var books = new List<Books>
{
    new Books {BookId = 0, Title = "1984", Author = "George Orwell", Year = 1949},
    new Books {BookId = 1, Title = "Brave New World", Author = "Aldous Huxley", Year = 1932},
    new Books {BookId = 2, Title = "Fahrenheit 451", Author = "Ray Bradbury", Year = 1953 },
    new Books {BookId = 3, Title = "Animal Farm", Author = "George Orwell", Year = 1945 },
    new Books {BookId = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },
    new Books {BookId = 5, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },
    new Books {BookId = 6, Title = "Moby-Dick", Author = "Herman Melville", Year = 1851 },
    new Books {BookId = 7, Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813 },
    new Books {BookId = 8, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Year = 1951 },
    new Books {BookId = 9, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Year = 1954 },
    new Books {BookId = 10, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 },
    new Books {BookId = 11, Title = "War and Peace", Author = "Leo Tolstoy", Year = 1869 },
    new Books {BookId = 12, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Year = 1866 },
    new Books {BookId = 13, Title = "The Brothers Karamazov", Author = "Fyodor Dostoevsky", Year = 1880 },
    new Books {BookId = 14, Title = "The Grapes of Wrath", Author = "John Steinbeck", Year = 1939 },
    new Books {BookId = 15, Title = "East of Eden", Author = "John Steinbeck", Year = 1952 },
    new Books {BookId = 16, Title = "Wuthering Heights", Author = "Emily Brontë", Year = 1847 },
    new Books {BookId = 17, Title = "Jane Eyre", Author = "Charlotte Brontë", Year = 1847 },
    new Books {BookId = 18, Title = "Les Misérables", Author = "Victor Hugo", Year = 1862 },
    new Books {BookId = 19, Title = "The Count of Monte Cristo", Author = "Alexandre Dumas", Year = 1844 },
    new Books {BookId = 20, Title = "Dracula", Author = "Bram Stoker", Year = 1897 }
};

        var readers = new List<Readers>
{
    new Readers {LastName = "Smith", BookId = 0, IssuedDate = new DateTime(2024, 2, 1), ReturnDate = new DateTime(2024, 2, 2) },
    new Readers { LastName = "Johnson", BookId = 1, IssuedDate = new DateTime(2023, 3, 5), ReturnDate = new DateTime(2023, 4, 10) },
    new Readers { LastName = "Williams", BookId = 2, IssuedDate = new DateTime(2022, 3, 12), ReturnDate = new DateTime(2022, 6, 12) },
    new Readers { LastName = "Brown", BookId = 3, IssuedDate = new DateTime(2024, 1, 8), ReturnDate = new DateTime(2025, 5, 11) },
    new Readers { LastName = "Jones", BookId = 4, IssuedDate = new DateTime(2021, 7, 3), ReturnDate = new DateTime(2021, 8, 6) },
    new Readers { LastName = "Garcia", BookId = 5, IssuedDate = new DateTime(2020, 8, 11), ReturnDate = new DateTime(2020, 9, 12) },
    new Readers { LastName = "Miller", BookId = 6, IssuedDate = new DateTime(2023, 11, 4), ReturnDate = new DateTime(2025, 4, 12) },
    new Readers { LastName = "Davis", BookId = 7, IssuedDate = new DateTime(2019, 9, 3), ReturnDate = new DateTime(2019, 9, 6) },
    new Readers { LastName = "Rodriguez", BookId = 8, IssuedDate = new DateTime(2024, 4, 1), ReturnDate = new DateTime(2024, 4, 10) },
    new Readers { LastName = "Martinez", BookId = 9, IssuedDate = new DateTime(2023, 10, 10), ReturnDate = new DateTime(2025, 6, 11) },
    new Readers { LastName = "Hernandez", BookId = 10, IssuedDate = new DateTime(2024, 6, 5), ReturnDate = new DateTime(2024, 5, 12) },
    new Readers { LastName = "Lopez", BookId = 11, IssuedDate = new DateTime(2020, 12, 2), ReturnDate = new DateTime(2021, 1, 10) },
    new Readers { LastName = "Gonzalez", BookId = 12, IssuedDate = new DateTime(2024, 7, 4), ReturnDate = new DateTime(2024, 8, 10) },
    new Readers { LastName = "Wilson", BookId = 13, IssuedDate = new DateTime(2024, 3, 5), ReturnDate = new DateTime(2025, 3, 3) },
    new Readers { LastName = "Anderson", BookId = 14, IssuedDate = new DateTime(2023, 4, 1), ReturnDate = new DateTime(2023, 4, 4) },
    new Readers { LastName = "Thomas", BookId = 15, IssuedDate = new DateTime(2021, 5, 3), ReturnDate = new DateTime(2021, 6, 10) },
    new Readers { LastName = "Taylor", BookId = 16, IssuedDate = new DateTime(2024, 2, 7), ReturnDate = new DateTime(2025, 7, 8) },
    new Readers { LastName = "Moore", BookId = 17, IssuedDate = new DateTime(2022, 11, 11), ReturnDate = new DateTime(2022, 12, 12) },
    new Readers { LastName = "Jackson", BookId = 18, IssuedDate = new DateTime(2023, 6, 10), ReturnDate = new DateTime(2023, 7, 11) },
    new Readers { LastName = "White", BookId = 19, IssuedDate = new DateTime(2024, 1, 1), ReturnDate = new DateTime(2024, 1, 11) },
    new Readers { LastName = "Harris", BookId = 20, IssuedDate = new DateTime(2023, 9, 12), ReturnDate = new DateTime(2025, 9, 12) }
};

        TaskA(books, readers, "George Orwell", new DateTime(1900, 1, 1), new DateTime(2024, 12, 31));

        TaskB(books, readers);

        TaskC(books, readers, 3);
    }
    public static void TaskA(List<Books> books, List<Readers> readers, string author, DateTime startDate, DateTime endDate)
    {
        var booksByAuthor = readers
            .Where(r => r.IssuedDate >= startDate && r.IssuedDate <= endDate)
            .Join(books, r => r.BookId, b => b.BookId, (r, b) => new { b.Title, b.Author })
            .Where(b => b.Author == author)
            .Select(b => b.Title);
        Console.WriteLine($"Назви книг автора - {author}, видані з {startDate.ToShortDateString()} до {endDate.ToShortDateString()}: ");
        foreach (var title in booksByAuthor)
        {
            Console.WriteLine(title);
        }
    }

    public static void TaskB(List<Books> books, List<Readers> readers)
    {
        var currentYear = DateTime.Now.Year;

        var unreturnedBooksCount = readers
            .Where(r => r.ReturnDate == null && r.IssuedDate.Year == currentYear)
            .Join(books, r => r.BookId, b => b.BookId, (r, b) => new { b.Year, r.IssuedDate })
            .Where(b => b.Year < 2000)
            .Count();

        Console.WriteLine($"Кількість книг неповернутих читачами, які були видані у минулому столітті та вибрані у поточному році: {unreturnedBooksCount}");
    }

    public static void TaskC(List<Books> books, List<Readers> readers, int N)
    {
        var currentYear = DateTime.Now.Year;

        var popularBooks = readers
            .Where(r => r.IssuedDate.Year == currentYear)
            .GroupBy(r => r.BookId)
            .OrderByDescending(g => g.Count())
            .Take(N)
            .Join(books, g => g.Key, b => b.BookId, (g, b) => new { b.Title, Count = g.Count() });

        Console.WriteLine($"Найбільш популярні книги, видані у поточному році: {N}: ");
        foreach (var book in popularBooks)
        {
            Console.WriteLine($"Назва: {book.Title}, Кількість видач: {book.Count}");
        }
    }
}
