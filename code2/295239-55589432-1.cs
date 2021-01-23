    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
   
    try {
        abc...
    } catch (DbUpdateException ex) {
        if (ex.InnerException.InnerException is SqlException sqlEx && sqlEx.Number == 2601) {
            return ex.ToString();
        } else {
            throw;
        }
    }
