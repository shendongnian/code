    using (TransactionScope transaction = new TransactionScope())
    {
        bool success = false;
        try
        {
            //your code here
            UpdateTable1();
            UpdateTable2();
            transaction.Complete();
            success = true;
        }
        catch (Exception ex)
        {
            // Handle errors and deadlocks here and retry if needed.
            // Allow an UpdateException to pass through and 
            // retry, otherwise stop the execution.
            if (ex.GetType() != typeof(UpdateException))
            {
                Console.WriteLine("An error occured. "
                    + "The operation cannot be retried."
                    + ex.Message);
                break;
            }
        }    
        if (success)
            context.AcceptAllChanges();
        else    
            Console.WriteLine("The operation could not be completed");
    
        // Dispose the object context.
        context.Dispose();    
    }
