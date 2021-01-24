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
            public int Num;
            public int Num2;
            public int Calculate(Book product) //This is important, I would like to keep practicing pass
            {
                Num = (product.Price);
                Num2 = product.Price2;
                Console.WriteLine(Num2);
                return Num + Num2;
            }
        }
    class Program
        {
            static void Main(string[] args)
            {
                var num = new Book();
                var checkNum = num.Price = 10; //these is the values
                var checkNum2 = num.Price2 = 20;
                var result = new Check();
                var checkNum3 = result.Calculate(num);//pass num  not new book
                Console.WriteLine(checkNum3.Num);
            }
        }
