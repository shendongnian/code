    IEnumerable<XElement> transactions = doc.
                                         Descendants("TransactionsResponse").
                                         Descendants("Transactions");
    foreach (XElement element in transactions)
    {
         String actionType = element.Descendants("ActionType").Single().Value;
         if(myActionTypes.Contains(actionType))
               //do whatever you want since you know the action 
               //type of the transaction now
    }
                   
