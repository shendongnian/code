    using ImpromptuInterface.Build;
    public static TInterface IsModuleEnabled<TInterface>(this TInterface obj) where TInterface : class
    {
        if (obj is ActLikeProxy)
        {
            return default(TInterface);//returns null
        }
        return obj;
    }
