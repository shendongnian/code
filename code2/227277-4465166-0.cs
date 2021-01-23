    var builder = new StringBuilder()
    
    foreach(var row in dataSet.Tables.First().Rows)
    {
       foreach(var cell in row.ItemArray)
       {
          builder.Append(cell.ToString());
          if(cell != row.Cells.Last())
             builder.Append("\t");
       }
       builder.Append(Environment.NewLine);
    }
    
    var file = new FileStream(filePath);
    var writer = new StreamWriter(file);
    writer.Write(builder.ToString());
    writer.Flush();
    writer.Close();
       
