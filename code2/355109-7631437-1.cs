    DataTable t = new DataTable();
    t.Columns.Add("Price");
    t.Columns["Price"].DataType=typeof(string);
    for (int i = 0; i < 10; i++)
    {
        DataRow r = t.NewRow();
        r.ItemArray=new object[]{i};
        t.Rows.Add(r);
    }
    object min = t.Compute("MIN(Price)",string.Empty);
    Console.WriteLine("Min: " +min); //PRINTS Min: 0
    try
    {
        object avg = t.Compute("AVG(Price)", string.Empty);
        Console.WriteLine("AVG: "+avg);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
            
