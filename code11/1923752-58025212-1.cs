    class Main 
    {
    
    	DataReader1 _dr;
        DataHandler _dh;
    	public Main()
    	{
    		_dr = new DataReader1();
    		_dh = new DataHandler();
    		BeginProcess();
    	}
    
    	public void BeginProcess()
    	{
    		//...code ommitted
    		ConfigModelHandler cm = new ConfigModelHandler(models);
    		cm.StartModelProcessing();
    	}
    
    	public void StartModelProcessing(IDataHandler1 dh)
    	{	
    		Worksheet sheet = dr.GetWorksheetByName("Your_CSV_File");
    		//Each model - each with their own sheet
    		for (int i = 0; i < models.Count; i++)
    		{
    				for (int j = 0; j < models[i].Count; j++)
    			{
    				Worksheet sheetInner = dr.GetWorksheetByName("Your_CSV_File");
    				//do stuff with sheet
    				var range = GetDestinationRange(sheetInner);
    			}
    
    			fileSaver.SaveFile(instances, filePath);
    		}
    	}
    
    	public Xcl.Range GetDestinationRange(Worksheet sheet)
    	{
            var lastRow = dh.GetLastRow(sheet);
    		string range = "A" + ((lastRow  + 1) + ":A" + (lastRow + 3));
            Xcl.Range rng = sheet.Range[range];
            return rng;
    	}
    }
