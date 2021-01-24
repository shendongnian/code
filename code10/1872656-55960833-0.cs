      foreach (Document document in documentsToDelete)
                        {
                            using (var dbContextTransaction = ctx.Database.BeginTransaction())
                            {
                                try
                                {
                                    document.Comment = "Deleted by loader service - not filed in time";
                                    ctx.SaveChanges();
    
                                    ctx.DeleteDocument(document.DocumentId, DateTime.Now, 0);
                                    ctx.SaveChanges();
    
                                    ctx.InsertDocumentHistory(document.DocumentId, "DELETE");
                                    ctx.SaveChanges();
    
                                    dbContextTransaction.Commit();
                                }
                                catch(Exception ex)
                                {
                                    dbContextTransaction.Rollback();
                                    var message = string.Format("Error occurred during method: {0}. Error message: {1}. Stack trace: {2}. Inner exception: {3}", methodName, ex.Message, ex.StackTrace, ex.InnerException);
                                    _log.ErrorFormat(message);
                                }
    
                            }
                        }
`
