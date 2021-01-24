     using System.Transactions;
    ....
           using (var scope = _db.Connection.BeginTransaction())
           {
                _db.Query("Posts").WhereNull("AuthorId").AsUpdate(new {
                   AuthorId = 10
               });
               ...
                scope.Commit();
            }
   
