    public static int GetResult<TType>(TType aObject) where TType: IFoo
    {
        if(aObject.Value == 12)
        {
            return 99;
        }
        return 20;
    }
