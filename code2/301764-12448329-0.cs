    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                    {
                        using (YeagerTechEntities DbContext = new YeagerTechEntities())
                        {
                            Category category = new Category();
    
                            category.CategoryID = cat.CategoryID;
                            category.Description = cat.Description;
    
                            // more entities here with updates/inserts
                            // the DbContext.SaveChanges method will save all the entities in their corresponding EntityState
    
                            DbContext.Entry(category).State = EntityState.Modified;
                            DbContext.SaveChanges();
    
                            ts.Complete();
                        }
                    }
