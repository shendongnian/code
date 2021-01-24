     public static void Main(string[] args)
        {
            Console.WriteLine("enter a string");
            string stng =Console.ReadLine();
            char[] revArray = stng.ToCharArray();
            Array.Reverse( revArray );
            Console.WriteLine(revArray);
        }
