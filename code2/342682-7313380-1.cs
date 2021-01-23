    static string[] titles;
    static void Main(string[] args)
    {
        string title;
        titles = new string[1]; // We can hold one value.
        Console.Write("Title of book: ");
        title = Console.ReadLine();
        getBookInfo(title);
    }
    static void getBookInfo(string title)
    {
        titles[0] = title;
    }
