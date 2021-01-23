    public static void PrepareChildControlsDuringPreInit(this Page page)
    {
        // Walk up the master page chain and tickle the getter on each one
        MasterPage master = page.Master;
        while (master != null) master = master.Master;
    } 
