        static void Main(string[] args)
        {
            dynamic i = int.MaxValue;
            long l = 15;
            i += l;
            Console.WriteLine(i.GetType());
            Console.WriteLine(i);
            Console.ReadLine();
        }
