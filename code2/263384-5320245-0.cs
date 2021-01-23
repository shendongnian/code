    viewModel.GroupedTransactions = transactionData     
        .GroupBy(x => new { DocumentId = x.DocumentId ?? "Un Documented" })
        .Zip(Enumerable.Range(0, int.MaxValue), (x, index) => new GroupedTransaction     
        {         
            DocumentId = x.Key.DocumentId,         
            Transactions = x.Select(y => new Transaction         
            {             
                Amount = y.CommitAmount,             
                ActivityType = y.ActivityType,             
                Number = index         
            })     
        })     
        .OrderBy(x => x.DocumentId); 
