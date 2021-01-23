           Console.WriteLine("Please enter 5 unique numbers....");
            List<int> uniqueNums = new List<int>() { };
            while (uniqueNums.Count < 5)
            {
                int input = Convert.ToInt32(Console.ReadLine());
                if (uniqueNums.Contains(input))
                {
                    Console.WriteLine("Add a different number");
                }
                uniqueNums.Add(input);
            }
            uniqueNums.Sort();
            foreach (var n in uniqueNums)
            {
                Console.WriteLine(n);
            }
