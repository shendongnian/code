    var intFileCount = 0;
    Dictionary<int, string[]> dctListRecords = null; 
    //initialize a capacity if you want 
    dctListRecords = new Dictionary<int, string[]>(strLinesStockRecord.Count());
    foreach (string strLineSplit in strLinesStockRecord)
    {
      lstSplitList2 = strLineSplit.Split(chrCOMMA_SEP).ToList();
      dctListRecords.Add(intFileCount, lstSplitList2.ToArray());
      //this allows you to use the string value inside of string[]
      lstSplitList2.Clear();
      intFileCount++;
    }
