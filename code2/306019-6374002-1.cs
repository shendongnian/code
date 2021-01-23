    var db = new StoreDataContext();
    using(var scope = new TransactionScope()){        
        foreach(var p in payments){
            db.payments.Insert(new payment 
                              {    order_fk = p.order_fk, 
                                   line_no = DbMethods.GetNextLine(p.order_fk),     
                                    amount = p.amount
                              });
            db.SubmitChanges(ConflictMode.FailOnFirstConflict);
        }
        scope.Complete();
    }
