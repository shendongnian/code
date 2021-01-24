    public static DataTable ObjectToData(object o)
    {
        DataTable dt = new DataTable("OutputData");
    
        DataRow dr = dt.NewRow();
        
    
        o.GetType().GetProperties().ToList().ForEach(f =>
        {
            try
            {
                f.GetValue(o, null);
                dt.Columns.Add(f.Name, typeof(string));
                dr[f.Name] = f.GetValue(o, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        });
    
        dt.Rows.Add(dr);
    
        return dt;
    }
