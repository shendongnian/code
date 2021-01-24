    myThread = new Thread(() => ThreaRefreshUI());
    myThread.Start();
     
    private void ThreaRefreshUI()
    {
        
        try
        {
    	this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
    	{	
          string ImagePath="";
          pictureBox1.Image = Image.FromFile(ImagePath);
          .......
    	});
        }
        catch (Exception ex)
        {
    
        }
    }
