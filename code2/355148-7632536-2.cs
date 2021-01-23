    private static void doHandleException(
    	Exception e)
    {
    	try
    	{
    		Log.Instance.ErrorException(@"Exception.", e);
    	}
    	catch (Exception x)
    	{
    		Trace.WriteLine(string.Format(
                    @"Error during exception logging: '{0}'.", x.Message));
    	}
    
    	var form = Form.ActiveForm;
    	if (form == null)
    	{
    		MessageBox.Show(buildMessage(e), 
                    "MyApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    	else
    	{
    		MessageBox.Show(form, buildMessage(e), 
                    "MyApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    }
