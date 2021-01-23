    (from result in db.CustomersRecords
    
                              group result
                                  by new { result.Invoice_Number, result.Date_Of_Transaction } into intermediateResult
                              orderby intermediateResult.Key.Date_Of_Transaction descending
                              select new { InvoiceNumber = intermediateResult.Key.Invoice_Number, DateOfTransaction = intermediateResult.Key.Date_Of_Transaction, TotalAmount = intermediateResult.Sum(result => result.Total_Amount) }).ToList();
