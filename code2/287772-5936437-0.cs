    (from deposit in DAOBase<CashBookDeposit, long>.GetIQueryableBusinessBase()
     let receipts = (from tempReceipts in deposit.TempReceipts
                     select tempReceipts)
     where deposit.Id == id
     select new CashBookDeposit
     {
         Id = deposit.Id,
    
         DepositeNumber = deposit.DepositeNumber,
         DocumentTypeName = deposit.CashBookDepositDocumentType.EnglishName,
         StatusName = deposit.CashBookDepositeStatus.EnglishName,
    
         CashbookName = deposit.CashBook.EnglishName,
         Collector = deposit.Collector,
         Partner = deposit.Partner,
         CashBookDepositDocumentType = deposit.CashBookDepositDocumentType,
         CreationDate = deposit.CreationDate,
    
         PaidAmount = deposit.TotalAmount,
         Description = deposit.Description,
    
         TempReceipts = (from receipt in receipts 
                         select new TempReceipt
                         {
                             Id = receipt.Id,
                             Code = receipt.Code,
                             ReceiptNo = receipt.ReceiptNo,
                             Amount = receipt.Amount,
                             BusinessPartnerName = receipt.Partner.ENName,
                             CollectorName = receipt.Collector.EnglishName,
                             StatusName = receipt.TempReceiptStatus.EnglishName,
                             CollectionDate = receipt.CollectionDate,
                             CreationDate = receipt.CreationDate,
                             Description = receipt.Description,
                         }).ToList()
     }).SingleOrDefault();
