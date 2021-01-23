    public static List<string> QUERY(string query, string dbpath)
    {
       string  cnStr = @"Provider=Microsoft.JET.OLEDB.4.0; data source=" + dbPath;
       oleconn = new OleDbConnection(cnStr);
       List<string>lstColumns = null;
       string[] strarryColumnNames = {}; //keep this just like this it's how you can declare dynamic array
       string strCommaDelimColumns = string.Empty;
       OleDbDataReader drdrRecord = null;
       OleDbConnection oleconn = null;
       
       using(OleDbCommand  olecmd new OleDbCommand(query, cnStr))
       {
    		olecmd.CommandTimeout = 60;
    		olecmd.CommandType = System.Data.CommandType.Text;  
    	    oleconn.Open();
    		//if you want to get the record count just setup a query with Select (count) as recCnt .... 
    		//do the oledrd execute here.. then call oledrdr.Close(); and assign the other query string to another execute reader
    		/* basically do something like this and replace what I have with what you need
    			var drdrRecordCntReader = olecmd.ExecuteReader();
                oledrdr.Read();
                intRecCount = (int)oledrdr[recCnt];//value returned from the Select Count(*)
                if (intRecCount == 0)
                {
                    return false;
                }//if (intRecCount == 0)		
    		*/
    		oledrdr = olecmd.ExecuteReader();
            lstColumns = new List<string>();
    		//load the field header contents here 
    	    for (int intCounter = 0; intCounter < oledrdr.FieldCount; intCounter++)
    	    {
    		  lstColumns.Add(oledrdr.GetName(intCounter));
    	    }		
            strarrayColumnNames = lstColumns.ToArray();		
    		strCommaDelimColumns = string.Join(",", strarryColumnNames);
    		//use the same lstColumns to add the data no need for a second while loop
    		//close the reader oledrdr
    		//use it again
    		try
            {
    			 //outter loop - Read row record by record 
    			for (int intCounter = 0; intCounter < intRecCount - 1; intCounter++) // figure out how to get record count
                {
    			   rdrDataReader.Read();
    			 //inner loop - read each field data within that row
    				 for (int intFieldcnt = 0; intFieldcnt < intColumnCnt; intFieldcnt++)
    				 {
    					//put your field data value code here
    				 }//for (int intFieldcnt = 0; intFieldcnt < intColumnCnt; intFieldcnt++)
    			 }
    		 }
    		 catch (Exception ex)
    		 {
    		 
    		 }
        }			
    }
