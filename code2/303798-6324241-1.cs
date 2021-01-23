    private void FindAndSetDate(WorkSheet ws, Dictionary<DateTime,string> dict)
    {
	    Range find = null;
	    foreach(KeyValuePair<DateTime,String> kvp in Dict)
	    {
		    find = ws.Cells.Find(kvp.Key, Type.Missing,
		    Microsoft.Office.Interop.Excel.XlFindLookIn.xlValues, Microsoft.Office.Interop.Excel.XlLookAt.xlWhole,
		    Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows, Microsoft.Office.Interop.Excel.XlSearchDirection.xlNext, false,
		    Type.Missing, Type.Missing);
	
		    if(find!=null) find.Offset[0,1].Value=kvp.Value;	
	    }	
	
    }
