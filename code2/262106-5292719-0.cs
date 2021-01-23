    SortedList<string, string> sortedList ... // input sortedList
    
    int rowsPerPage = 7;
    int columnsPerPage = 2;
    var result = from col in
                     (from i in sortedList.Select((item, index) => new { Item = item, Index = index })
                     group i by (i.Index / rowsPerPage) into g
                     select new { ColumnNumber = g.Key, Items = g })
                 group col by (col.ColumnNumber / columnsPerPage) into page
                 select new { PageNumber = page.Key, Columns = page };
    
    foreach (var page in result)
    {
        Console.WriteLine("Page no. {0}", page.PageNumber);
        foreach (var col in page.Columns)
        {
            Console.WriteLine("\tColumn no. {0}", col.ColumnNumber);
            foreach (var item in col.Items)
            {
                Console.WriteLine("\t\tItem key: {0}, value: {1}", item.Item.Key, item.Item.Value);
            }
        }
    }
