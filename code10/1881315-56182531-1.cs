    List<string> ItemsTradingDebitList = new List<string>(); //This might be missing in your code
    if (Particulars == Constants.TAG_OPENING_STOCK)
    {
        ItemsTradingDebitList.Add("Amount");    
        ItemsTradingDebitList.Add("Particulars");   
    }
    if(Particulars == Constants.TAG_PURCHASE)
    {
        ItemsTradingDebitList.Add("Amount");    
        ItemsTradingDebitList.Add("Particulars"); 
    }
    if(Particulars == Constants.TAG_SALES)
    {
        ItemsTradingDebitList.Add("Amount");    
        ItemsTradingDebitList.Add("Particulars"); 
    }
 
