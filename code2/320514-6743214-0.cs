        static void Main()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (DateTime.Now > new DateTime(2011, 3, 13)) Console.WriteLine("abc");
            }
        }
