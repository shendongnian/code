    DataTable dt = new DataTable();
    dt.Columns.Add("Id", typeof(int));
    dt.Columns.Add("Text", typeof(string));
    dt.Columns.Add("Value1", typeof(string));
    dt.Columns.Add("Value2", typeof(int));
    
    dt.Rows.Add(1, "Test1", "584", 12);
    dt.Rows.Add(2, "Test2", "32", 123);
    dt.Rows.Add(3, "Test3", "425", 54);
    dt.Rows.Add(4, "Test1", "4", 755);
    dt.Rows.Add(5, "Test5", "854", 879);
    dt.Rows.Add(6, "Test2", "1", null);
    dt.Rows.Add(7, "Test2", "999", 3);
    
    var duplicates = dt.Rows.OfType<DataRow>().GroupBy(x => x[1]).Where(x => x.Count() > 1).ToList();
    //get the current highestId (first column) so that when we remove duplicates and a new row the new row will get the next available id
    var highestId = dt.Rows.OfType<DataRow>().Max(x => (int)x[0]);
    
    //enumerate all duplicates
    foreach (var duplicate in duplicates)
    {
        //get the highest value of each column
        var newId = ++highestId;
        var newText = duplicate.Key;
        var newValue1 = duplicate.Max(x => x[2]); //this does a string comparison, instead of a numeric one, this means that for example that 2 is bigger then 10
    
        // use this if you need numeric comparison
        var newValue1AsNumeric = duplicate.Select(x =>
        {
            if (int.TryParse(Convert.ToString(x[2]), out var value))
                return value;
    
            return (int?)null;
        }).OfType<int>().Max(); 
    
        var newValue2 = duplicate.Select(x => x[3]).OfType<int>().Max();
    
        //enumerate each row of the duplicate
        foreach (var dataRow in duplicate)
            dt.Rows.Remove(dataRow);
    
        dt.Rows.Add(newId, newText, newValue1, newValue2);
    }
