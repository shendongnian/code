    class MyConsoleApp
    {
        static void Main(string[] args)
        {
            //create a new instance of the ISBN/book class. you're prompted as part
            //of the constructor.
            isbn myFavoriteBook = new isbn();
            //new class contains the method for checking validity 
            bool isValid = CheckDigit.CheckIsbn(myFavoriteBook.GetIsbn());
            //write out the results of the validity.
            Console.WriteLine(string.Format("Your book {0} a valid ISBN", 
                                       isValid ? "has" : "doesn't have"));
            Console.ReadLine();
        }
    }
