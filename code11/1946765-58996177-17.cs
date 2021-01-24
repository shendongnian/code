    RefreshUIAsync().Wait();  
    
    public async Task RefreshUIAsync()
    {
       await Task.Run(() => {
       This.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
    	{	
          string ImagePath="";
          pictureBox1.Image = Image.FromFile(ImagePath);
          .......
    	});
       });
    }
