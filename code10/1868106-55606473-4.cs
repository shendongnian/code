    List<BankDepositHistoryDTO> BankDepositHistoryDTOs = new List<BankDepositHistoryDTO>();
    foreach(var item in query)
    {
       BankDepositHistoryDTO b = new BankDepositHistoryDTO();
    
       b.AccountId = item.AccountId;
       b.Id = item.Id;
       b.Amount = item.Amount;
       b.AdditionalData = item.AdditionalData;
       b.ClientIp = item.ClientIp;
       b.Gateway = item.Gateway;
       b.PaymentRefNumber = item.PaymentRefNumber;
       b.ReturnUrl = item.ReturnUrl;
       b.State = item.State;
       b.Uuid = item.Uuid;
    
       BankDepositHistoryDTOs.Add(b);
    }
