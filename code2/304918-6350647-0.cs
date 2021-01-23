        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Jeff", "John", "Joe", "Jack", "Jim" };
            List<string> otherNames = new List<string>() { "Jeff", "John", "Joe", "Jack", "Jim" };
            Random r = new Random();
            for (int i = 4; i >= 0; i--)
            {
                int pick1 = r.Next(i);
                int pick2 = r.Next(i);
                while (names[pick1] == otherNames[pick2])
                {
                    pick2++;
                    if (pick2 >= otherNames.Count) pick2 = 0;
                }
                if (names.Count == 2)
                {
                    // when you only have 2 names left, if the other names match...
                    if (names[1 - pick1] == otherNames[1 - pick2])
                    {
                        // swap one of the picked names
                        pick2 = 1 - pick2;
                    }
                }
                Console.Write(names[pick1]); Console.Write(" != "); Console.WriteLine(otherNames[pick2]);
                names.RemoveAt(pick1);
                otherNames.RemoveAt(pick2);
            }
            Console.ReadKey();
        }
