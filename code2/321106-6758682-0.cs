    using (TransactionScope ts = new TransactionScope())
            {
               try
                  {
                  ...
                   bank.setID(BankName, Branch);
                   throw new System.InvalidOperationException("sht happens");
                   check.addCheck(check);
                   ...
                   ts.Complete();
                  }
              catch
                  {
                   //catch the exception
                   //ts.Complete() is not called, thus update/insert rollbacks
                  }
            }
