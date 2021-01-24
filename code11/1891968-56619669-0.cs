    var mylines = lines.GroupBy(g => g).Select(s => new { Name = s, Count = s.Count() });
                foreach (var line in mylines)
                {
                    Console.WriteLine($"{line.Name.Key} | {line.Count}");
                }  
