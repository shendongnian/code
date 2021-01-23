    SetTrue(ref b1);
    SetFalse(ref b3);
    Invert(ref b5);
    // ...
    public static void SetTrue(ref bool field)
    {
        DoCommonStuff();
        field = true;
    }
    public static void SetFalse(ref bool field)
    {
        DoCommonStuff();
        field = false;
    }
    public static void Invert(ref bool field)
    {
        DoCommonStuff();
        field = !field;
    }
    private static void DoCommonStuff()
    {
        // ...
    }
