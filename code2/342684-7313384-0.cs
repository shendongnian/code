    private static string[] titles;
        static void Main(string[] args)
        {
           
            string title;
            Console.Write("Title of book: ");
            title = Console.ReadLine();
            getBookInfo(ref title);
            displayBooks(titles);
        }
        static void getBookInfo(ref string title)
        {
            //titles[0] = title;
            titles = new string[] {title};
        }
        static void displayBooks(string[] titles)
        {
            Console.WriteLine("{0}", titles[0]);
        }
