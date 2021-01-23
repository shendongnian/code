    string[] collection = new[] { "DET", "ATE", "RTI" };
    var files = from f in checkedListBox1.CheckedItems.OfType<string>()
                orderby Array.IndexOf(collection, f.Substring(0, 3))
                select f;
    List<string> collection2 = new List<string> { "DET", "ATE", "RTI" };
    var files2 = from f in checkedListBox1.CheckedItems.OfType<string>()
                orderby collection2.IndexOf(f.Substring(0, 3))
                select f;
    Dictionary<string, int> collection3 = new Dictionary<string, int> 
                { { "DET", 1 }, { "ATE", 2 }, { "RTI", 3 } };
            
    Func<string, int> getIndex = p =>
    {
        int res;
        if (collection3.TryGetValue(p, out res))
        {
            return res;
        }
        return -1;
    };
    var files3 = from f in checkedListBox1.CheckedItems.OfType<string>()
                    orderby getIndex(f.Substring(0, 3))
                    select f;
