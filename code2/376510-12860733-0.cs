    void EnsureClose<TObjectContext>(Action<TObjectContext> dbAction) where TObjectContext : ObjectContext, new()
        {
            using (var objContext = new TObjectContext())
            {
                try
                {
                    dbAction(objContext);
                }
                finally
                {
                    objContext.Connection.Close();
                }
            }
        }
