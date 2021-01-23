    try
    {
        // Your code...
        // Could also be before try if you know the exception occurs in SaveChanges
        context.SaveChanges();
    }
    catch (DbEntityValidationException e)
    {
        foreach (var eve in e.EntityValidationErrors)
        {
            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                eve.Entry.Entity.GetType().Name, eve.Entry.State);
            foreach (var ve in eve.ValidationErrors)
            {
                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    ve.PropertyName, ve.ErrorMessage);
            }
        }
        throw;
    }
