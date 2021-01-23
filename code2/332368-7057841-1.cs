    class Program
    {
        enum Cats { Fluffy, Furry, Bald };
        enum Dogs { Big, Fat, Ugly };
        static void Main(string[] args)
        {
            string name = "Fluffy";
            Type currentEnum = typeof(Cats);
            if(currentEnum.Equals(typeof(Cats)))
            {
                Cats cat = (Cats)Enum.Parse(typeof(Cats), name);
                Console.WriteLine("old " + cat);                        // Prints "old Fluffy"
                Console.WriteLine("new " + (cat + 1));                  // Prints "new Furry"  // TODO: Add error check for the + 1
            }
            else if (currentEnum.Equals(typeof(Dogs)))
            {
                Dogs dog = (Dogs)Enum.Parse(typeof(Cats), name);
                Console.WriteLine("old " + dog);
                Console.WriteLine("new " + (dog + 1));
            }
            Console.ReadKey();
        }
    }
