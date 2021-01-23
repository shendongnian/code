            string csvFile = @"myfile.csv";
            string[] lines = File.ReadAllLines(csvFile);
            var values = lines.Select(l => new { FirstColumn = l.Split(',').First(), Values = l.Split(',').Skip(1).Select(v => int.Parse(v)) });
            foreach (var value in values)
            {
                Console.WriteLine(string.Format("Column '{0}', Sum: {1}, Average {2}", value.FirstColumn, value.Values.Sum(), value.Values.Average()));
            }
