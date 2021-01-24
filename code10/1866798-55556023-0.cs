    for (int i = 0; i < transactionlist.Count; i++)
    {
        BankDepositHistoryDTO b = new BankDepositHistoryDTO();
        b.AccountId = transactionlist[i].AccountId;
        b.Id = transactionlist[i].Id;b
        b.Amount = transactionlist[i].Amount;
        b.AdditionalData = transactionlist[i].AdditionalData;
        b.ClientIp = transactionlist[i].ClientIp;
        b.Gateway = transactionlist[i].Gateway;
        b.PaymentRefNumber = transactionlist[i].PaymentRefNumber;
        b.ReturnUrl = transactionlist[i].ReturnUrl;
        b.State = transactionlist[i].State;
        b.Uuid = transactionlist[i].Uuid;
        bdto.Add(b);
    }
