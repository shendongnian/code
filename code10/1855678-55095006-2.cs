      foreach (string name in table.Keys)
            {
                List<int> value = table[name];
                double totalGrade = 0;
                Console.Write($"{name} exam scores: ");
                foreach (int valueList in value)
                {
                    Console.Write($" {valueList}");
                    double grade = valueList;
                    totalGrade = grade + valueList;
                }
                double avarage = totalGrade / value.Count();
                Console.WriteLine($"");
                Console.WriteLine($"Average: {Math.Round(avarage,2)}");
                Console.WriteLine($"");
                Console.ReadKey();
            }
