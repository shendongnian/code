            var p = @"C:\temp\Values.csv";
            var lines = File.ReadAllLines(p);
            var data = lines.Skip(1);
            var NotOrdered = data.Select(line => new
            {
                Value = Double.Parse(line.Split(',')[2]),
                Priority = Int32.Parse(line.Split(',')[1]),
                ID = Int32.Parse(line.Split(',')[0])
            });
            var sorted = NotOrdered
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Priority);
                    
            var sortedAndConcatedString = sorted.Select(x => x.ID.ToString() + "," + 
            x.Priority.ToString() + "," + x.Value.ToString()).ToArray();
            File.WriteAllLines(@"C:\temp\sorted.csv",
                                 sortedAndConcatedString);
            
