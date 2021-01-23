        dynamic obj = new ExpandoObject();
        obj.Apples = 5;
        obj.Oranges = 1;
        obj.Bananas = 2;
        var properties = (IDictionary<string, object>)obj;
        properties.
            ToList().
            ForEach(x => Console.WriteLine("Property={0},Value={1}",x.Key,x.Value));
