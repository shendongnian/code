    foreach (APTran row in Base.Transactions.Cache.Cached)
    {
        if (Globalvar.GlobalBoolean != true || row.TranDesc == null || !row.TranDesc.Contains("Data Backup"))
        {
            continue;
        }
    
        //Found my row
        var curyl = Convert.ToDecimal(Globalvar.Globalred);
        row.CuryLineAmt = curyl * -1;
        Base.Transactions.Update(row);
    }
