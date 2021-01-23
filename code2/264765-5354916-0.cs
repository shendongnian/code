    private void Application_Start(object sender, EventArgs e)
    {
    	try
    	{
    		SetupHelper.SetUp()
    		//Awesome
        }
    	catch(InvalidDisplaySettingsException ex)
    	{
    		//Do Something based on the type of the exception
    	}
    	catch(DatabaseConfigurationException ex)
    	{
    		//Do something based on the type of the exception
    	}
    	catch(Exception ex)
    	{
    		//Now sh.. hit the fan
    	}
    }
