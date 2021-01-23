    const int ProgressBarLength = 230;
    foreach (TransactionDetail item in list)
    {
        var itemProgress = ((ProgressBarLength / (double)item.PurchasesRequired)
                            * Convert.ToInt32(item.TransactionAmount));
        item.ProgressBar = Math.Min((int)itemProgress, ProgressBarLength);
    }
