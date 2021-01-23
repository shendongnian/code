    public MyObj this[string index]
    {
        get
        {
            foreach (var o in My_Enumerable)
            {
                if (o.Name == index)
                {
                    return o;
                }
            }
        }
        set
        {
            foreach (var o in My_Enumerable)
            {
                if (o.Name == index)
                {
                    var i = My_Enumerable.IndexOf(0);
                    My_Enumerable.Remove(0);
                    My_Enumerable.Add(value);
                }
            }
        }
    }
