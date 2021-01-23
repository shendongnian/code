    public static void Update(employee Employee)
    {
        using(var db = new MySqlEntities())
        {
            db.employees.Attach(Employee);
            db.employees.Context.ObjectStateManager.ChangeObjectState(Employee, System.Data.EntityState.Modified);
            db.SaveChanges();
        }
    }
