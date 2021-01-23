    public Type GetSomeType(int num)
    {
        switch (num)
        {
            case 0:
                return typeof(DateTime);
            case 1:
                return typeof(int);
            default:
                return null;
        }
    }
