    static void Main()
    {
        foreach(string s in Get())
        {
            Console.WriteLine(s);
        }
    }
    static IEnumerable<string> Get() {
        var source = new[] {1, 2, 3, 4, 5};
        Task<string> outstandingItem = null;
        Func<object, string> transform = x => ProcessItem((int) x);
        foreach(var item in source)
        {
            var tmp = outstandingItem;
            // note: passed in as "state", not captured, so not a foreach/capture bug
            outstandingItem = new Task<string>(transform, item);
            outstandingItem.Start();
            if (tmp != null) yield return tmp.Result;
        }
        if (outstandingItem != null) yield return outstandingItem.Result;
    }
    static string ProcessItem(int i)
    {
        return i.ToString();
    }
