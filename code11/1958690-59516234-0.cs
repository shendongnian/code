    var msg = e.Message.Text;
    try 
	{
		var output = new DataTable().Compute(msg, null).ToString();
		// It was a valid expression - do something with the result
		Send(output);
	}
	catch (Exception ex)
	{
		// Not a valid expression
        // Do something in this error case such as providing the detail back to the user
        SendError(ex.Message);
	}
