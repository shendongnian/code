      TransactionRequest transactionRequest = new TransactionRequest()
        {
            Amount = amount,
            CustomerId = customer.Id,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true
            }
        };
        Result<Transaction> result = Gateway.Transaction.Sale(transactionRequest);
