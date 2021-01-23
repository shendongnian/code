    StringBuilder str = new StringBuilder();
    foreach (DataRow dr in this.NorthwindDataSet.Customers) 
    {
     foreach (object field in dr.ItemArray) 
     {
       str.Append(field.ToString + ",");
     }
     str.Replace(",", vbNewLine, str.Length - 1, 1);
    }
    
    try 
    {
     My.Computer.FileSystem.WriteAllText("C:\\temp\\testcsv.csv", str.ToString, false);
    } 
    catch (Exception ex) 
    {
     MessageBox.Show("Write Error");
    }
