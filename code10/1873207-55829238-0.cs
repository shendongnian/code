    public static string ConvertFixedWidthToCsv(string data)
        {
            var rows = data.Split(
                new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            var returnRows = new List<string>();
            foreach (var row in rows)
            {
               
                if (string.IsNullOrWhiteSpace(row))
                {
                    continue;
                }
                var parsed = Regex.Replace(row, @"\s+", ",");
                returnRows.Add(parsed);
            }
            return String.Join("\r\n", returnRows);
        }
