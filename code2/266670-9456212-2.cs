     catch (DbEntityValidationException dbEx)
     {
        foreach (var validationErrors in dbEx.EntityValidationErrors)
        {
           foreach (var validationError in validationErrors.ValidationErrors)
           {
              Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                                      validationErrors.Entry.Entity.GetType().FullName,
                                      validationError.PropertyName,
                                      validationError.ErrorMessage);
           }
        }
     }
