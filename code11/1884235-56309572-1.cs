                string[] unsorted = { "1","2","100","12303479849857341718340192371",
                                "3084193741082937","3084193741082938","111","200" };
                var groups = unsorted.OrderBy(x => x.Length).GroupBy(x => x.Length).ToArray();
                List<string> results = new List<string>();
                foreach (var group in groups)
                {
                    string[] numbers = group.ToArray();
                    for(int i = 0; i < numbers.Count() - 1; i++)
                    {
                        for(int j = i + 1; j < numbers.Count(); j++)
                        {
                            if(numbers[i].CompareTo(numbers[j]) == 1)
                            {
                                string temp = numbers[i];
                                numbers[i] = numbers[j];
                                numbers[j] = temp;
                            }
                        }
                    }
                    results.AddRange(numbers);
                }
