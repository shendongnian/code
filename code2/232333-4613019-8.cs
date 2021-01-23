    public void GetCurrentWeekSummary(String strXMLFile, int TransactionType_ID, DateTime selectedDate)
    {
                    XDocument doc = null;
                    XMLFileManager XMLDocObj = new XMLFileManager();
                    doc = XMLDocObj.LoadXMLFile(strXMLFile);
                    DateTime startDate = selectedDate.Date.AddDays(-(int)DateTime.Today.DayOfWeek), // prev sunday 00:00
                    endDate = startDate.AddDays(7); // next sunday 00:00
                    var vTransaction = from x in doc.Descendants("Transaction")
                               where ((DateTime)x.Element("Current_Date")).Date >= startDate
                               && ((DateTime)x.Element("Current_Date")).Date < endDate
                               where x.Element("TransactionType_ID").Value == TransactionType_ID.ToString() 
                               select new Transaction(x);
    }
 
    public void GetCurrentMonthSummary(String strXMLFile, int TransactionType_ID, DateTime selectedDate)
    {
                    XDocument doc = null;
                    XMLFileManager XMLDocObj = new XMLFileManager();
                    doc = XMLDocObj.LoadXMLFile(strXMLFile);
    
                    int CurrentYear = selectedDate.Year;
                    int CurrentMonth = selectedDate.Month;
    
                    DateTime startDate = new DateTime(CurrentYear, CurrentMonth, 1);
                    DateTime endDate = startDate.AddMonths(1).AddMinutes(-1);
    
    
                    var vTransaction = from x in doc.Descendants("Transaction")
                                   where ((DateTime)x.Element("Current_Date")).Date >= startDate
                                   && ((DateTime)x.Element("Current_Date")).Date < endDate
                                   where x.Element("TransactionType_ID").Value == TransactionType_ID.ToString()
                                   select new Transaction(x);
    }
