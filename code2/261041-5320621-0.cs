    public static void SelectRandomColumns(DataTable dataTable, string col1, string col2)
    {
        // Select into an anonymous type here, but you could
        // select into a custom class
        var query = from row in dataTable.AsEnumerable()
                    select new
                    {
                        p1 = row[col1],
                        p2 = row[col2]
                    };
	
        // Do whatever you need to do with the new collection of items
        foreach (var item in query)
        {
            Console.WriteLine("{0}: {1}, {2}: {3}", col1, item.p1, col2, item.p2);
        }			
    }
