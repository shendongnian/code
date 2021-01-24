    foreach (string name in table.Keys)
            {
                List<int> value = table[name];
                Console.Write($"{name} exam scores: ");
                foreach (int valueList in value)
                {
                    Console.Write($" {valueList}");
                
                }
                Console.WriteLine("");
                Console.ReadKey();
            }
        }
