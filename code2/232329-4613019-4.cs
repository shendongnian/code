    int CurrentYear = DateTime.Today.Year;
    int CurrentMonth = DateTime.Today.Month;
    
    DateTime startDate = new DateTime(CurrentYear, CurrentMonth, 1);
    DateTime endDate = startDate.AddMonths(1).AddMinutes(-1);
    var vTransaction = from x in doc.Descendants("Transaction")
                                       where ((DateTime)x.Element("Current_Date")).Date >= startDate
                                       && ((DateTime)x.Element("Current_Date")).Date < endDate
                                       where x.Element("TransactionType_ID").Value == TransactionType_ID.ToString()
                                       select new Transaction(x);
