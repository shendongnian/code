     using (AccountingDbContext dbContext = new AccountingDbContext())
            {
                Transaction objEmp = new Transaction();
                objEmp.VoucherNo = ((from  transction in dbContext.Transactions
                                   select transction.Id).Max() + 1).ToString();
                objEmp.TransactionType = "Payment";
                dbContext.Transactions.Add(objEmp);
                dbContext.SaveChanges();
            }
