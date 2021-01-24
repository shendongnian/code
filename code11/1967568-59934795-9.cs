    public async ...... ActionName()
    {
      var process = Process.Start("....");
      var wrapper = new SafeProcess(() => HttpContext.Current.Response.IsClientConnected == false, process);
    
     var state = await wrapper.WaitAsync();
    }
