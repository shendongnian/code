        //Use this method.
        public void Map(object PreEqual, string PreEqProperty, object PostEqual, string PostEqProperty)
        {
            PreEqual.GetType().GetProperty(PreEqProperty).SetValue(PreEqual, PostEqual.GetType().GetProperty(PostEqProperty).GetValue(PostEqual, null), null);
        }
        //Use Map method somewhere you want, like this:
        //myRefObj is your source object and myRefProp is its property that you want to map to other objects.
        foreach(SomeType item in CollectionOfSomeType)
        {
             Map(item, "myRefProp", myRefObj, "myRefProp");
        }    
I think it will work with primitive types. Can you try and let me know if it works?
