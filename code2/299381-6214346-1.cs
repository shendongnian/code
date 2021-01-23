    protected override void OnStop()
    {
      if (serviceHost != null)
      {
          try {
              serviceHost.Close();
          }catch{
              //could throw an exception if it is in a bad state
          }finally{
              serviceHost = null;
          }
      }
    }
