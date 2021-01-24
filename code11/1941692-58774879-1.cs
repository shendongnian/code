        public class Product
        {
            public string Title { get; set; }
            public int Price { get; set; }
        }
        public class Book : Product
        {
            public string Isbn { get; set; }
            public int Price2 { get; set; }
        }
        public class Check : Book
        {
           
            public int Calculate(Book product) //This is important, I would like to keep practicing pass
            {
               return product.Price+product.Price2
            }
        }
    class Program
        {
            static void Main(string[] args)
            {
                var num = new Book();
                 num.Price = 10; 
                 num.Price2 = 20;
                var result = new Check();
               
             Console.WriteLine(result.Calculate(num)); //pass num  not new book
            }
        }
