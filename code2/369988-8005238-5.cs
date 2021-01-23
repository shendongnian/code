    public void Foo()
    {
        var list = new List<MyObject>();
        list.Add(one);
        list.Add(two);
        foreach (var obj in list.HasDate())
        {
            //You should really have this be culture aware since you're working
            //with DateTime...
            Console.WriteLine(String.Format(CultureInfo.CurrentCulture,
                "{0}: {1}", obj.Name, obj.Date.Value));
        }
    }
    public void Foo2()
    {
        var list = new List<MyObject>();
        list.Add(one);
        list.Add(two);
        //Use LINQs ToList() to get a new List<T>
        var newList = list.HasDate().ToList();
        ...
    }
