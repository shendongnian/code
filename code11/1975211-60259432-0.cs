            for (int i = 1; i < lines.Length - 1; i++)
            {
                values = lines[i].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 2)
                {
                    DataRow row = table.NewRow();
                    row[0] = values[0].Substring(0, 4);
                    row[1] = values[0].Substring(4).Trim();
                    row[2] = values[1].Substring(0, 5);
                    row[3] = values[1].Substring(5).Trim();
                    table.Rows.Add(row);
                }
            }
