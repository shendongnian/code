    public void insert(CashExpense item)
    {    
       using(CEADataStoreDataContext CashExpensesDB = new CEADataStoreDataContext())
       {
           CashExpensesDB.CashExpenses.InsertOnSubmit(item); 
           CashExpensesDB.SubmitChanges();
       }
    }
