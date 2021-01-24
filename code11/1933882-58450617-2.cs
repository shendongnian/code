    private static void SetDateTaken(string path, string samplePath, DateTime NEWdate)
    {         
    	Encoding _Encoding = Encoding.UTF8;
    	Image theImage = new Bitmap(path);
    	PropertyItem[] propItems = theImage.PropertyItems;
    			   
    	var DataTakenProperty1 = propItems.FirstOrDefault(a => a.Id.ToString("x") == "9003");
    	var DataTakenProperty2 = propItems.FirstOrDefault(a => a.Id.ToString("x") == "9004");
    
    	//// this is where you do the hack
    	if (DataTakenProperty1 == null)
    	{
    		Image sampleImage = new Bitmap(samplePath);
    		PropertyItem fakePropertyItem1 = sampleImage.PropertyItems.FirstOrDefault(a => a.Id.ToString("x") == "9003");
    		fakePropertyItem1.Value = _Encoding.GetBytes(NEWdate.ToString("yyyy:MM:dd HH:mm:ss") + '\0');
    		fakePropertyItem1.Len = fakePropertyItem1.Value.Length;
    		theImage.SetPropertyItem(fakePropertyItem1);
    
    		PropertyItem fakePropertyItem2 = sampleImage.PropertyItems.FirstOrDefault(a => a.Id.ToString("x") == "9004");
    		fakePropertyItem2.Value = _Encoding.GetBytes(NEWdate.ToString("yyyy:MM:dd HH:mm:ss") + '\0');
    		fakePropertyItem2.Len = fakePropertyItem2.Value.Length;
    		theImage.SetPropertyItem(fakePropertyItem2);
    	}
    	else
    	{
    		DataTakenProperty1.Value = _Encoding.GetBytes(NEWdate.ToString("yyyy:MM:dd HH:mm:ss") + '\0');
    		DataTakenProperty2.Value = _Encoding.GetBytes(NEWdate.ToString("yyyy:MM:dd HH:mm:ss") + '\0');
    		theImage.SetPropertyItem(DataTakenProperty1);
    		theImage.SetPropertyItem(DataTakenProperty2);
    	}
    
    	theImage.Save(newPath);
    	theImage.Dispose();
    }
