    string[] lines = System.IO.File.ReadAllLines(@"C:\TextFile1.txt");
            var dictionary = new Dictionary<int, List<string>>();
            foreach (var line in lines)
            {
                string[] vals = line.Split("-");
                var result = Convert.ToInt32(vals[0].Trim());
                var name = vals[1].Trim();
                if (!dictionary.ContainsKey(Convert.ToInt32(vals[0].Trim())))
                {
                    dictionary.Add(result, new List<string> { new string(name) });
                }
                else
                {
                    var duplicate = dictionary.GetValueOrDefault(result);
                    duplicate.Add(name);
                }
                
            }
            var orderedList = dictionary.OrderByDescending(r => r.Key);
            Console.Clear(); //Clears the console
            Console.WriteLine("======================================");
            Console.WriteLine("Quiz Leaderboard!");
            Console.WriteLine("Shown below are the top 10 users");
            Console.WriteLine("======================================");
            foreach (var keyValuePair in orderedList)
            {
                Console.WriteLine(" Result = " + keyValuePair.Key);
                foreach (var val in keyValuePair.Value)
                {
                    Console.WriteLine("     Name: " + val);
                }
                
            }
