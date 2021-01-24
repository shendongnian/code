    someclass(serializedJson)
    {
        JavascriptSerializer js = new JavascriptSerializer();
        var newObj = (someClass)(js.deserialize(serializedJson, typeof(serializedJson)));
        Price = // ... some code
    }
    pblic string Price { get; }
