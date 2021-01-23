    private static IEnumerable<IDocumentExtractor> EnumerateInstances()
    {
        IEnumerable<Type> types = EnumerateTypes();
        foreach(Type type in types)
        {
            var oResult = Test(type);
            if (oResult != null)
            {
                yield return oResult;
            }
        }
    }
    private static IDocumentExtractor Test(Type type)
    {
        try
        {
            IDocumentExtractor extractor = Activator.CreateInstance(type) as IDocumentExtractor;
             return extractor;
        }
        catch
        {
            return null;
            //_log.WarnFormat("Type {0} couldn't be instanced.", type.Name);
        }
    }
