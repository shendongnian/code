    WindowsIdentity wi = (WindowsIdentity)User.Identity;
    WindowsImpersonationContext wic = null;
                
    try
    {
        wic = wi.Impersonate();
        if (wi.IsAuthenticated)
        {
             //Do stuff here on network as Current User
             // i.e. asyncFileUpload.SaveAs(location);
        }
                    
    }
    catch(Exception ex)
    {
        //Log Error Here
       
        if (wic != null)
          wic.Undo();
        return;
    }
    finally
    {
         if (wic != null)
             wic.Undo();
    }
