    public List<MyCustomRoot> PerformMapping(List<IRootObject> rootObjects)
    {
        var returnList = new List<CustomRoot>();
        foreach(var rootObject in rootObjects)
        {
            var abstractObject = (MyCustomRoot)Mapper.Map(rootObject, rootObject.GetType(), typeof(MyCustomRoot));
            returnList.Add(abstractObject);
        }
        return returnList;
    }
