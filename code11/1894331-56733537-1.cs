    public void printTransactionDetails(List<ResultClass> result, int transactionId) {
         var transaction = result.FirstOrDefault(x => x.TransactionId == transactionId);
         if (transaction != null) {
             Console.WriteLine(transaction.TransactionID + " " + transaction.StaffName + " " + transaction.StoreName + " " + transaction.CustomerName + " " + item.Total);
         }
    }
