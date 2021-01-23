     public static int? n { get; set; } 
        static void Main(string[] args)
        {
           
        Console.WriteLine(n == null);
         //you also can check using 
         Console.WriteLine(n.HasValue);
            Console.ReadKey();
        }
