    class Main 
    {
    
    	DataReader1 _dr;
    
    	public Main()
    	{
    		_dr = new DataReader1();
    		
    		BeginProcess();
    	}
    
    	public void BeginProcess()
    	{
    		var dh = new DataHandler1();
    		//...code ommitted
    		ConfigModelHandler cm = new ConfigModelHandler(models);
    		cm.StartModelProcessing(dh); //passing an instance not injecting
    	}
    
    	public void StartModelProcessing(IDataHandler1 dh)
    	{	
    		Worksheet sheet = dr.GetWorksheetByName("Your_CSV_File");
    		//Each model - each with their own sheet
    		for (int i = 0; i < models.Count; i++)
    		{
    				for (int j = 0; j < models[i].Count; j++)
    			{
    				Worksheet sheetInner 	testRange = dr.GetWorksheetByName("Your_CSV_File");
    				//do stuff with sheet
    				var range = GetDestinationRange(sheetInner);
    			}
    
    			fileSaver.SaveFile(instances, filePath);
    		}
    	}
    
    	public Xcl.Range GetDestinationRange(Worksheet sheet)
    	{
            DataHandler dh = new DataHandler();
    		string range = "A" + ((dh.GetLastRow(sheet) + 1) + ":A" + (dh.GetLastRow(sheet) + 3));
            Xcl.Range rng = sheet.Range[range];
            return rng;
    	}
    }
