    public async Task Exec()
    {
        MyDbContext db = new MyDbContext();
        var foos = await db.GetFooAsync(1);
    }
