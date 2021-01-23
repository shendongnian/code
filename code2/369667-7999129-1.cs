    static void Current_TransactionCompleted(object sender, TransactionEventArgs e)
    {
        Console.WriteLine("A transaction has completed:");
        Console.WriteLine("ID:             {0}", e.Transaction.TransactionInformation.LocalIdentifier);
        Console.WriteLine("Distributed ID: {0}", e.Transaction.TransactionInformation.DistributedIdentifier);
        Console.WriteLine("Status:         {0}", e.Transaction.TransactionInformation.Status);
        Console.WriteLine("IsolationLevel: {0}", e.Transaction.IsolationLevel);
    }
