    bool result ;
    Task<bool> task = Task.Run<bool>(async () => await CustomTaskAsync());
    str = task.Result;
    
    public async Task<bool> CustomTaskAsync()
    {
       bool result;
       result= await Task.Factory.StartNew(() => CustomTask());
       return result;
    }
    
    private bool CustomTask()
    {           
      bool result;  
     return result;
    }
