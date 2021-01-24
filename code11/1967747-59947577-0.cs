  	  // Get item list from your database. Hardcoded here.
    var items = new List<string>{ "Week 02 [2020]", "Week 03 [2020]", "Week 36 [2019]", "Week 40 [2019]", "Week 47 [2019]", "Week 52 [2019]" };
    // Sort in-memory. Assumes formats are FIXED.
    items.Sort((x,y) => {
        int result = string.Compare(y.Substring(9,4), x.Substring(9,4));
        if (result == 0)
        {
             result = string.Compare(y.Substring(5,2), x.Substring(5,2));
        }
        return result;
    });
    // Now assign items to your listbox.
    // For demo, output result of the sort
    foreach (var s in items)
	{
    	Console.WriteLine(s);
	}
