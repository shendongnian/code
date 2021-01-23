            try { 
                
                db.SaveChanges();                              
            }
            catch (System.Data.UpdateException ex)    
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
            {
                Console.WriteLine(ex.InnerException);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                throw;
            }
