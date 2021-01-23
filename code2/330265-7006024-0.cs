    {
        Entities myentities;
        try
        {
            myentities = new MyEntities();
            myentities.AddTotblUsers(user);
            myentities.SaveChanges();
        }
        finally
        {
            if (myentities != null)
                ((IDisposable)myEntities).Dispose();
        }
    }
