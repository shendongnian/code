     Thread thread = new Thread(ThreaRefreshUI);
     thread.Start();
    
     public void ThreaRefreshUI()
     {
       try
       {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
    	{	string ImagePath="";
                    pictureBox1.Image = Image.FromFile(ImagePath);
                    .......
    	});
       }
       catch (Exception ex)
       {
    	   
       }
     }
