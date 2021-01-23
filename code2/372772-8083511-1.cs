    public object GetSomeType(int num)
    {
        switch (num)
        {
            case 0:
                return DateTime.Now;
            case 1:
                return 5;
            default:
                return null;
        }
    }
