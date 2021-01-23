    private void ThreadFunc(object fileName)
    {
    	string fileToUpdate = (string)fileName;
    	while (Run)
    	{
    	    _event.WaitOne(); 
    
    		string data;
    		using (StreamReader readerStream = new StreamReader(fileToUpdate))
    		{
    			data = readerStream.ReadToEnd();
    		}
    
    		if (Textbox.InvokeRequired)
    		{
    			UpdateTextCallback back = new UpdateTextCallback(UpdateText);
    			Textbox.BeginInvoke(back, new object[] { data });
    		}
    		
                    Thread.Sleep(1000); 
    	}       
    }
    
    
    private void UpdateText(string data)
    {
    	Textbox.Text = data;
    }
