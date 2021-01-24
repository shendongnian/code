c#
            var dtLines = new List<string>();
            string[] columnNames = dt.Columns
                .Cast<DataColumn>()
                .Select(column => column.ColumnName)
                .ToArray();
            var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
            dtLines.Add(header);
            var valueLines = dt.AsEnumerable()
                .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));
            dtLines.AddRange(valueLines);
            File.WriteAllLines("excel.csv", dtLines);
