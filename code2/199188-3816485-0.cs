    using (var db = new MyDbDataContext())
    {
        var myRecord= db.MyTable.FirstOrDefault();
        Console.WriteLine(myRecord.MyColumn.ToString());
    }
