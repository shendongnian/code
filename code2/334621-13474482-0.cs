    try{
    ...
    catch ( DbEntityValidationException ex )
       {
    foreach ( var validationErrors in ex.EntityValidationErrors )
        {
         foreach ( var validationError in validationErrors.ValidationErrors )
         {
          System.Diagnostics.Trace.TraceInformation( "Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage );
         }
        }
    }
