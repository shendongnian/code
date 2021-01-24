            static void Main(string[] args)
        {
            string[] low256 = File.ReadAllLines(@"C:\Users\Dingo Ice\Downloads\Low_256.txt");
            Console.WriteLine("Choose a file to use, enter 1: Low, 2: High or 3: Mean");
            int choice = Convert.ToInt32(Console.ReadLine());
            //Sort Arrays into ascending order
            Array.Sort(low256);
            //Sort Arrays into descending order
            Array.Reverse(low256);
            if (choice == 1)
            {
                for (int i = 0; i < low256.Length; i++)
                {
                    if (i % 10 == 0)
                    {
                        Console.WriteLine(low256[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter 1, 2 or 3");
            }
            Console.WriteLine("Enter an exact value to search for in the selected array");
            string searchValue = Console.ReadLine();
            searchValue = searchValue.ToLower().Trim();
            List<int> indexes = new List<int>();
            if (choice == 1)
            {
                for (int i = 0; i < low256.Length; i++)
                {
                    string value = low256[i].ToLower().Trim();
                    if (searchValue == value)
                    {
                        Console.WriteLine($"Search value '{value}' found at position: '{i}'.");
                        indexes.Add(i);
                    }
                }
                if (indexes.Count == 0)
                {
                    Console.WriteLine("The search value was not found in the selected array");
                }
            }
            Console.ReadLine();
        }
