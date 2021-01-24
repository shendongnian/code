    Excel.Range excelRangeA = workSheet.Columns["A:A"];
    var rngFind = excelRangeA.Find("A");
    var found = false;
    while (rngFind!=null || !found)
    {
    	if (rngFind.Offset[0, 1].Value == "Y")
    	{
    		string value = rngFind.Offset[0, 2].Value;
    		found = true;
    		MessageBox.Show(value);
    	}
    	else
    	{
    		rngFind = excelRangeA.FindNext(rngFind);
    	}
    }
