    private async void SubmitButton_Click( object sender, EventArgs e )
    {
		try
		{
			//Awaited async call that returns a value.
    
			//Call to utility classes that eventually call GoToPage( string page, bool transfer )
    	
		}	
		catch ( ThreadAbortException tEx )
		{
			Thread.ResetAbort();
			HttpContext.Current.Response.SuppressContent = true;
			HttpContext.Current.ApplicationInstance.CompleteRequest();
		}
    }
