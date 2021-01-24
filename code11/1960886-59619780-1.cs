    private object GetKidsOfBaseClass(Type baseType)
    {
        var blahKids = 
        AppDomain.CurrentDomain.GetAssemblies().SelectMany(ass => ass.GetTypes())
            .Where(p => p.IsSubclassOf(baseType)).ToList();
        return blahKids;
    }
