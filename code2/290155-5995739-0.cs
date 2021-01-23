    DataTable dt = ...;
    string formatStr = String.Join(", ", Enumerable.Range(0, dt.Columns.Count)
    	.Select(c => dt.Columns[c].ColumnName + " = {" + c + "}").ToArray());
    
    for (int i = 0; i < dt.Rows.Count; i++)
    	Console.WriteLine("Row " + i + ": " + String.Format(formatStr, dt.Rows[i].ItemArray));
