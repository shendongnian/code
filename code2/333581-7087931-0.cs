    private void ProcessCSV(string sourceCsvFilePath, string destCsvFilePath)
    {
        // Read contents of source file
        var lines = File.ReadAllLines(sourceCsvFilePath, Encoding.Default);
        
        // Process the old file contents
        var table = new List<List<string>>();
        foreach(var line in lines)
        {
            var cells = new List<string>();
            for(int i =0;i<line.Length;i++)
            {
                if(line[i] == '\"')
                {
                    var cellBuilder = new StringBuilder(line[i].ToString());
                    i++;
                    while (i < line.Length && line[i] != '\"')
                    {
                        cellBuilder.Append(line[i].ToString());
                        i++;
                    }
                    cells.Add(cellBuilder.ToString().Trim('\"'));
                }
                else if(line[i] != ',')
                {
                    var cellBuilder = new StringBuilder(line[i].ToString());
                    i++;
                    while (i < line.Length && line[i] != ',')
                    {
                        cellBuilder.Append(line[i].ToString());
                        i++;
                    }
                    cells.Add(cellBuilder.ToString().Trim('\"'));
                }
            }
            table.Add(cells);
        }
        // Create a new table in the order: OldTable.Col2, OldTable.Col4, OldTable.Col0, "OldTable.Col1 OldTable.Col5 OldTable.Col6"
        var newTable = new List<List<string>>();
        foreach(var row in table)
        {
            var cells = new List<string>();
            cells.Add(row[2].Contains(',') ? string.Concat("\"", row[2], "\"") : row[2]);
            cells.Add(row[4].Contains(',') ? string.Concat("\"", row[4], "\"") : row[2]);
            cells.Add(row[0].Contains(',') ? string.Concat("\"", row[0], "\"") : row[2]);
            string str = string.Format("{0} {1} {2}", row[1], row[5], row[6]);
            cells.Add(str.Contains(',') ? string.Concat("\"", str, "\"") : str);
            newTable.Add(cells);
        }
        // Prepare the file contents
        var linesToWrite = new string[newTable.Count];
        int lineCounter = 0;
        foreach(var row in newTable)
        {
            StringBuilder rowBuilder = new StringBuilder();
            foreach(var cell in row)
            {
                rowBuilder.AppendFormat("{0},", cell);
            }
            linesToWrite[lineCounter++] = rowBuilder.ToString().Trim(',');
        }
        // Write the contents to CSV
        File.WriteAllLines(destCsvFilePath, linesToWrite, Encoding.Default);
    }
