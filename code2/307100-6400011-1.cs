        class Program
        {
            static void Main(string[] args)
            {
    
                var array = "hello world".ToCharArray();
    
                Array.Sort(array);
    
                Console.WriteLine(new String(array));
                Console.ReadLine();
            }
        }
