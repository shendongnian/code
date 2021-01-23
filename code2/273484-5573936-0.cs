    // this is your datatable
    DataTable table = new DataTable();
    table.Columns.Add("Salesman", typeof(string));
    table.Columns.Add("ClientID", typeof(int));
    //insert your data
    table.Rows.Add("Bob", 1);
    table.Rows.Add("Bob", 2);
    table.Rows.Add("Bob", 3);
    table.Rows.Add("Tom", 4);
    table.Rows.Add("Joe", 5);
    table.Rows.Add("Joe", 6);
    table.Rows.Add("Tim", 7);
    table.Rows.Add("Tim", 8);
    // query with LINQ 
    var query = from row in table.AsEnumerable()
                group row by row.Field<string>("Salesman") into sales
                orderby sales.Key
                select new
                {
                    Name = sales.Key,
                    CountOfClients = sales.Count()
                };
    // print result
    foreach (var salesman in query)
    {
        Console.WriteLine("{0}\t{1}", salesman.Name, salesman.CountOfClients);
    }
