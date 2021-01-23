    using (SqlTransaction transaction = connection.BeginTransaction())
    {
           // These methods will update all relevant command objects’ transaction property
           adapter1.EnlistTransaction(transaction);
           adapter2.EnlistTransaction(transaction);
     
           adapter1.Update(table1);
           adapter2.Update(table2);
     
           transaction.Commit();
    }
