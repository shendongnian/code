    protected void AsyncFileUploadComplete(object oSender, AsyncFileUploadEventArgs e)
    {
        try
        {   
            AsyncFileUpload oFileUploadControl = GetFileUploadInstance(ContainerId, (AsyncFileUpload)oSender);
        }
        catch (exception ex)
        {
        }
    }
          
    private AsyncFileUpload GetFileUploadInstance(Control oContainer, AsyncFileUpload oSender)
    {
        // Place all of your popup controls in a global container, look for the sender as a child control
        foreach (Control oControl in oContainer.Controls)
            if (oControl.Controls.Count != 0 && oControl.FindControl("m_afuFileUpload") == oSender)
                return (AsyncFileUpload)oControl;
        return new AsyncFileUpload(); // || throw new Exception("Could not find ASyncFileUpload Instance");
    }
