    public void UpdateCurrencyTime(string currencySymbol, DateTime time)
    {
       var item = CCDataList.Where(c => c.Symbol == currencySymbol).FirstOrDefault();
       if(item != null)
           item.Time = time;
    }
