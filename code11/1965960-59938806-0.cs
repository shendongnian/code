       public async Task<List<ResultClass>> Load()
       {
           try
           {
               var query = "SELECT * from procedure_Sessions";
               var result = await Db.QueryMultipleAsync(query).ConfigureAwait(false);
               return result.Read<ResultClass>().ToList();
           }
           catch (Exception exception)
           {
               Console.WriteLine();
               throw;
           }
        }
