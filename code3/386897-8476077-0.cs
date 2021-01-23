    public static void GetByID(DataTable table, int testID)
    {
        // bla bla bla
    }
    // calling the function
    using(DataTable table = new DataTable())
    {
        TestService.GetByID(table, 5);
    }
