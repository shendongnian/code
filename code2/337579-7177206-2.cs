    // Reusable method
    public IQueryable<SomeObject> GetSomeObjectsByFilter(Context c)
    {
         return
             from someObject in context.SomeObjects
             where c.B.A.Amount < 1000
             where c.Roles.Contains(r => r.Name == "Admin")
             select someObject;
    }
