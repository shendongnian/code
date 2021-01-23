    class MyConsoleApp
    {
        static void Main(string[] args)
        {
            isbn myFavoriteBook = new isbn();
            bool isValid = CheckDigit.CheckIsbn(myFavoriteBook.GetIsbn());
            Console.WriteLine(string.Format("Your book {0} a valid ISBN", 
                                       isValid ? "has" : "doesn't have"));
            Console.ReadLine();
        }
    }
