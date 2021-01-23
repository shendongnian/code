    List<string> aList = new List<string>();
    aList.Add("1");
    aList.Add("2");
    aList.Add("3");
    
    yourTableAdapter.ClearBeforeFill = true;
    yourTableAdapter.Fill(yourDataSet.yourTableName, ""); //clears table
    
    foreach (string a in aList)
    {
        yourTableAdapter.ClearBeforeFill = false;
        yourTableAdapter.Fill(yourDataSet.yourTableName, a);
    }
    yourTableAdapter.Dispose();
