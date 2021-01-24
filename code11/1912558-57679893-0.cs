      using(AppDbContext db = new AppDbContext())
    {
       var transaction = new Transaction()
            {
                BankAccountId = bankAccount.Id,
                Amount = amount,
                TransactionDateTime = DateTime.Now,
                TransactionType = TransactionType.Deposit
            };
    
        // save them back to the database
        //Add new Employee to database
             db.Transactions.InsertOnSubmit(transaction);
    
             //Save changes to Database.
             db.SubmitChanges();
    }
    
    
         using(AppDbContext db = new AppDbContext())
        {
            // get the record
            Transaction dbProduct = db.Transactions.Single(p => p.BankAccountId == 1);
    
        // set new values
        dbProduct.TransactionDateTime = DateTime.Now; 
        dbProduct.TransactionType =  TransactionType.Deposit;
    
        // save them back to the database
        db.SubmitChanges();
    }
