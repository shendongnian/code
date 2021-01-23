        dynamic bling = new ExpandoObject();
        bling.Prop = 5;
        var properties = (IDictionary<string, object>)bling;
        properties.
            ToList().
            ForEach(x => Console.WriteLine("Name={0}, Value={1}", x.Key, x.Value));
