    public Transaction(string transDate, IEnumerable<T> items)
    {
        DateTime tmpDate = DateTime.Parse(transDate);
    
        var deposits = from t in App.ViewModel.AllTransactions
                            where t.TransDate <= new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, 23, 59, 59, 999)
                            where t.TransType == (int)TransType.Deposit
                            select t.TransAmount;
    
        var withdrawals = from t in App.ViewModel.AllTransactions
                            where t.TransDate <= new DateTime(tmpDate.Year, tmpDate.Month, tmpDate.Day, 23, 59, 59, 999)
                            where t.TransType == (int)TransType.Withdrawal
                            select t.TransAmount;
    
        decimal total = (deposits.Sum() - withdrawals.Sum());
    
        this.TransAmount = total;
        this.TransDate = transDate;
        this.Items = new List<T>(items);
    }
