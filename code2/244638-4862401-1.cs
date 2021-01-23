    private void WriteImageToFile(object imageData)
    {
    	while (keepWritingImages)
    	{
    		if (arrGlobalData.Count > 0)
    		{
    			ImageData data = arrGlobalData[0];
    			try
    			{
    				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    				string fName = myDirectory + @"/" + Convert.ToString(data.fileName) + @".spe";
    				using (Stream myStream = new FileStream(fName, FileMode.Create))
    				{
    					bf.Serialize(myStream, data.image);
    				}
    			}
    			catch
    			{
    			}
    			finally
    			{
    				arrGlobalData.Remove(data);
    			}
    		}
    		
    		Thread.Sleep(10);
    	}
    }
