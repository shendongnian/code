    public void TestFunc(Action<type1, type2> doSomething)
    {
        foreach(var item in myLookup)
        {
            var x = item.Key;
            foreach(var subItem in item)
            {
                doSomething(x, subItem);
            }
        }
    }
