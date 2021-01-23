    public bool UpdateTables()
    {
        using(var context = new MyDBContext())
        {
            // use context to UpdateTable1();
            // use context to UpdateTable2();
            context.SaveChanges();
        } 
    }
