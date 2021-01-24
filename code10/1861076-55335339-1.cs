    if(ex is DbEntityValidationException dbException)
      {                 
       foreach (var eve in dbException.EntityValidationErrors)
        {                    
                        foreach (var ve in dbException.EntityValidationErrors.SelectMany(entity => entity.ValidationErrors))
                        {
                            sbErrorList.AppendLine(
                                                    String.Format(" Entity: \"{0}\", Action: \"{1}\", Property: \"{2}\", Value: \"{3}\", Error: \"{4}\"",
                                                    eve.Entry.Entity.GetType().Name, 
                                                    eve.Entry.State,
                                                    ve.PropertyName,
                                                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                                    ve.ErrorMessage)
                                                   );
                        }
                        #region Removing Entity Validation Error from current context : Rollback Changes                       
                        
                        // checks the State property of the DbEntityEntry causing the error
                        switch (eve.Entry.State)
                        {
                            case EntityState.Added:
                                eve.Entry.State = EntityState.Detached; // changed to Detached so that the entry won't be considered a part of the DbSet for future calls
                                break;
                            case EntityState.Modified:
                                eve.Entry.CurrentValues.SetValues(eve.Entry.OriginalValues); // the modified values (the values causing the error) are flushed out by replacing them with the OriginalValues.
                                eve.Entry.State = EntityState.Unchanged;
                                break;
                            case EntityState.Deleted:
                                eve.Entry.State = EntityState.Unchanged; // changed to Unchanged so that the entity is undeleted
                                break;
                        }
                        #endregion
                    }                   
                }
