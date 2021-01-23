    protected override void OnStop()
    {
      if (serviceHost != null)
      {
          serviceHost.Close();
          serviceHost = null;
      }
    }
