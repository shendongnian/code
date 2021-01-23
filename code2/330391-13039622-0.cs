    protected void m_fuTenantDocs_FileUploadComplete(object oSender, AsyncFileUploadEventArgs e)
    {
        try
        {   
            FileUploadControl oFileUploadControl = FileUploadInstance(ContainerId, (AsyncFileUpload)oSender);
        }
        catch (exception ex)
        {
        }
    }
          
    private FileUploadControl FileUploadInstance(Control oContainer, AsyncFileUpload oSender)
    {
        // Place all of your popup controls in a global container, look for the sender as a child control
        foreach (Control oControl in oContainer.Controls)
            if (oControl.Controls.Count != 0 && oControl.FindControl("m_afuFileUpload") == oSender)
                return (FileUploadControl)oControl;
        return new FileUploadControl();
    }
