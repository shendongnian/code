    class Program
    {
        static int Main(string[] args)
        {
           
            foreach (string b in args)
                Console.WriteLine(b+"   ");
            
            Console.ReadKey();
            aa();
            return 0;
        }
        public static void aa()
        {
            string []aaa={"www.stackoverflow.com"};
            Console.WriteLine(Main(aaa));
        }
       
    }
   
}
