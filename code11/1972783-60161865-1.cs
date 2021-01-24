    if(Enum.TryParse<TransactionTypes>(entries[index, 2], true, out TransactionTypes parsed){
        switch (parsed)
        {
           case TransactionTypes.Deposit:
              rbDeposit.Checked = true;
              break;
           case TransactionTypes.Withdrawal:
              rbWithdrawal.Checked = true;
              break;
           default:
              rbServiceFee.Checked = true;
              break;
        }
    }
    else{
        throw new Exception("Unknonw enum string");
    }
