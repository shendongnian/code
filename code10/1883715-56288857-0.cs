    public bool UpdateTable()
    {
        DatabaseContext _db = new DatabaseContext(); //database context instance
        int MyId = 100; //sample Id
        DateTime MyDateTime = new DateTime(2019, 5, 24, 12, 30, 52); //sample DateTime
        var p = _db.Table.Where(x => x.Id == MyId && x.SomeDateTime > 
            MyDateTime ).FirstOrDefault(); //the targeted record of the database
        if (p != null)
        {
           p.SomeDateTime = DateTime.Now;
           _db.SaveChanges();
           return true;
        }
        return false;
    }
