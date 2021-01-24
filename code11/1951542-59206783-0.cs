    public static void Main()
    {
        var books = new Book[]
        {
            new Book() {GStitle = "E"},
            new Book() {GStitle = "D"},
            new Book() {GStitle = "C"},
            new Book() {GStitle = "B"},
            new Book() {GStitle = "A"}
        };
        Console.WriteLine("Before sort.");
        foreach (var book in books)
        {
            Console.WriteLine(book.GStitle);
        }
        Array.Sort(books, (x, y) => string.Compare(x.GStitle, y.GStitle, StringComparison.InvariantCulture));
        //BookSort(books);
        Console.WriteLine("After sort.");
        foreach (var book in books)
        {
            Console.WriteLine(book.GStitle);
        }
    }
    public class Book
    {
        public string GStitle { get; set; }
    }
    public static void BookSort(Book[] books)
    {
        for (int y = 0; y < books.Length; y++)
        {
            for (int x = 0; x < books.Length - 1 - y; x++)
            {
                if (string.Compare(books[x].GStitle, books[x + 1].GStitle, StringComparison.InvariantCulture) > 0)
                {
                    var temp = books[x];
                    books[x] = books[x + 1];
                    books[x + 1] = temp;
                }
            }
        }
    }
