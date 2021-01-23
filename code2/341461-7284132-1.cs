    public void WriteTable(DataTable table, Stream outputStream)
    {
        // Create writer
        StreamWriter writer = new StreamWriter(outputStream);
    
        // Compute max lengths to build correct tabular columns
        Dictionary<string, int> maxLengths = new Dictionary<string, int>();
    
        foreach (DataColumn column in table.Columns)
        {
            maxLengths.Add(column.ColumnName, column.ColumnName.Length);
    
            foreach (DataRow row in table.Rows)
            {
                maxLengths[column.ColumnName] = Math.Max(
                    maxLengths[column.ColumnName], 
                    Convert.ToString(row[column.ColumnName]).Length);
            }
        }
    
        // Build horizontal rule to separate headers from data
        string horizontalRule = "+";
    
        foreach (DataColumn column in table.Columns)
        {
            horizontalRule += String.Format("-{0}-+", new string('-', maxLengths[column.ColumnName]));
        }
    
        writer.WriteLine(horizontalRule);
    
        // Write headers
        writer.Write("|");
    
        foreach (DataColumn column in table.Columns)
        {
            writer.Write(" {0," + (-(maxLengths[column.ColumnName])) + "} |", column.ColumnName);
        }
    
        writer.WriteLine();
    
        writer.WriteLine(horizontalRule);
    
        // Write data
        foreach (DataRow row in table.Rows)
        {
            writer.Write("|");
    
            foreach (DataColumn column in table.Columns)
            {
                writer.Write(" {0," + (-(maxLengths[column.ColumnName])) + "} |", row[column.ColumnName]);
            }
    
            writer.WriteLine();
        }
    
        writer.WriteLine(horizontalRule);
    
        // Close writer
        writer.Close();
    }
