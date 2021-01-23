        using (TransactionScope scope = new TransactionScope())
        {
          foreach(var connStr in listOfConnStr)
          {
              using(var db = new MyDataContext(connStr);
             {
                 // do update here.
             }
          }
        }
