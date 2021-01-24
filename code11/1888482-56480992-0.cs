        Stopwatch time = new Stopwatch();
        
                    time.Start();
        //COMPARE YOUR CODE (.Copy, Clone or Develop yourself)
                    DataTable dtTarget = dtSource.CopyDataTable(new List<string>() { "A", "B" });
        
                    foreach (DataColumn column in dtTarget.Columns)
                    {
                        Console.WriteLine("ColumnName : {0}", column.ColumnName);
        
                        foreach (DataRow row in dtTarget.Rows)
                        {
                            Console.WriteLine("Rows : {0}", row[column.ColumnName]);
                        }
                    }
        
                    time.Stop();
        
                    Console.WriteLine("{0}", time.Elapsed);
    
    
    
    public static class DataTableHelper
        {
            public static DataTable CopyDataTable(
               this DataTable dtSource,
                List<string> columnsName)
            {
    
                DataTable dtTarget = new DataTable();
                if (dtSource.Columns.Count > 0)
                {
                    
                    foreach (DataColumn columnSource in dtSource.Columns)
                    {
                        var columnTargetMapped = columnsName.FirstOrDefault(c => c == columnSource.ColumnName);
    
                        if(columnTargetMapped == null)
                        {
                            continue;
                        }
    
                        dtTarget.Columns.Add(columnTargetMapped);
                        
                        foreach (DataRow drSource in dtSource.Rows)
                        {
                            var valueColumn = drSource[columnSource];
    
                            DataRow drTarget = dtTarget.NewRow();
    
                            drTarget[columnTargetMapped] = valueColumn;
    
                            dtTarget.Rows.Add(drTarget);
                        }
                    }
                }
    
                return dtTarget;
            }
