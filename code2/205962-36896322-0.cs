            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                SqlException innerException = ex.InnerException.InnerException as SqlException;
                if (innerException != null && (innerException.Number == 2627 || innerException.Number == 2601))
                {
                    //your handling stuff
                }
                else
                {
                    throw;
                }
            }
