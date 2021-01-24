            var fileLines = File.ReadAllLines("file.csv");
            var randomGenerator = new Random();
            var newFileLines = new List<string>();
            foreach (var fileLine in fileLines)
            {
                var lineValues = fileLine.Split(',');
                lineValues[1] = randomGenerator.Next(1000, int.MaxValue).ToString();
                var newLine = string.Join(",", lineValues);
                newFileLines.Add(newLine);
            }
            File.WriteAllLines("file.csv", newFileLines);
