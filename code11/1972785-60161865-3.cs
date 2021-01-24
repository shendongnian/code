    if(Enum.TryParse<TransactionTypes>(entries[index, 2], true, out TransactionTypes parsed){
        switch (parsed)
        {
           case TransactionTypes.Deposit://constant value, no issue
              rbDeposit.Checked = true;
              break;
           case TransactionTypes.Withdrawal://constant value, no issue
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
