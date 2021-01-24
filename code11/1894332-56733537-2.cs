    public void printTransactionDetails(int transactionId) {
         var context = new Context();
            var result = (from sale in context.PurchaseHeads
                     join line in context.PurchaseLines on sale equals line.PurchaseHead
                     join staff in context.Staffs on sale.Staff equals staff
                     join store in context.Stores on sale.Store equals store
                     join customer in context.Customers on sale.Customer equals customer
                     join product in context.Products on line.Product equals product
                     group new { line.Quantity, product.Price } by new
                     { sale.ID,
                         StaffName = staff.Name,
                         StoreName = store.Name,
                         CustomerName = customer.Name} into gr
                     select new
                     {
                         TransactionID = gr.Key.ID,
                         StaffName = gr.Key.StaffName,
                         StoreName = gr.Key.StoreName,
                         CustomerName = gr.Key.CustomerName,
                         Total = gr.Sum(x => x.Quantity * x.Price),
                     }).FirstOrDefault(c => c.TransactionId == transactionId); 
         if (transaction != null) {
             Console.WriteLine(transaction.TransactionID + " " + transaction.StaffName + " " + transaction.StoreName + " " + transaction.CustomerName + " " + item.Total);
         }
    }
