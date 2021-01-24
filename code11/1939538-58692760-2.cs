    void Loop(IEnumerable<object> list, Func<object, List<string>> member)
    {
        foreach (var i in list)
        {
            foreach (var j in member(i))
            {
                string str = (string)j;
                ..................
    
            }
        }
    }
