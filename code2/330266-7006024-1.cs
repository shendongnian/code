    {
        Entities myentities = new MyEntities();
        try
        {
            myentities.AddTotblUsers(user);
            myentities.SaveChanges();
        }
        finally
        {
            if (myentities != null)
                ((IDisposable)myEntities).Dispose();
        }
    }
