    protected override void OnSessionChange(SessionChangeDescription changeDescription)
    {
       base.OnSessionChange(changeDescription);
    
       switch (changeDescription.Reason)
       {
          case SessionChangeReason.SessionLogon:
          {
             string user = "";
             foreach (ManagementObject currentObject in _wmiComputerSystem.GetInstances())
             {
                user = currentObject.Properties["UserName"].Value.ToString().Trim();
             }
          } break;
       }
    }
