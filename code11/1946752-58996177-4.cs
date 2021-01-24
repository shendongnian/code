    bool result ;
    Task<bool> task = Task.Run<bool>(async () => await RefreshUIAsync());
    str = task.Result;
    
    public async Task<bool> RefreshUIAsync()
    {
       bool result;
       result= await Task.Factory.StartNew(() => RefreshUI());
       return result;
    }
    
    private string RefreshUI()
    {           
      bool result;
      try
      {
       	 this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
    	{	
          string ImagePath="";
          pictureBox1.Image = Image.FromFile(ImagePath);
          .......
    	});
    	result=true;
      }
      catch (Exception ex)
      {
    	  result=false;
      }  
     return result;
    }
