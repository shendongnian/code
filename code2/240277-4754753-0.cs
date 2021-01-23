    var dt = new DataTable();
    dt.Columns.Add("Id", typeof(int));
    dt.Columns.Add("Name", typeof(string));
    dt.Rows.Add(1, "Hello");
    dt.Rows.Add(2, "World");
    dt.Rows.Add(1, "Foo"); // dupe key
    
    var nvc = new NameValueCollection();
    foreach (DataRow row in dt.Rows)
    {
        string key = row[0].ToString();
        // tidy up key here
        nvc.Add(key, row[1].ToString());
    }
    
    // display nvc
    foreach (var key in nvc.AllKeys)
        Console.WriteLine("{0}: {1}", key, nvc[key]);
