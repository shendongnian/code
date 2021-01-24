            string filePath = @"C:/Data.csv";
            var lines = File.ReadLines(filePath).ToList();
            
            // Add new Column
            var newColumn = ";Header7";
            lines[0] = lines[0] += newColumn;
            // Adds items to the new column
            for (int index = 1; index < lines.Count; index++)
            {
                var rowItems = lines[index].Split(';');
                lines[index] = $"{lines[index]};{rowItems[0]}{rowItems[1]}";
            }
            File.WriteAllLines(filePath, lines);
