    class Program
    {
        static void Main(string[] args)
        {
            string test = "test";
            
            //string as char array:
            //iterate through char collection
            foreach (char c in test)
            {
               //do something
            }
            //access elements by index
            Console.WriteLine("Contents of char array : {0}, {1}, {2}, {3}", test[0], test[1], test[2], test[3]);
            Console.ReadKey();
        }
    }
