    List<object> list = new List<object>();
    list.Add("one");
    list.Add(2);
    list.Add('3');
    Type desiredType = typeof(System.Int32);
    if (list.Any(w => w.GetType().IsAssignableFrom(desiredType)))
    {
        //do something
    }
