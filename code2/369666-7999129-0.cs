    try
    {
        //Create the transaction scope
        using (TransactionScope scope = new TransactionScope())
        {
            //Register for the transaction completed event for the current transaction
            Transaction.Current.TransactionCompleted += new TransactionCompletedEventHandler(Current_TransactionCompleted);
            // proces the transaction
        }
    
    }
    catch (System.Transactions.TransactionAbortedException ex)
    {
        Console.WriteLine(ex);
    }
    catch (System.Transactions.TransactionException ex)
    {
        Console.WriteLine(ex);
    }
    catch
    {
        Console.WriteLine("Cannot complete transaction");
        throw;
    }
