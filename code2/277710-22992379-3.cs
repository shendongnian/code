    try
    {
    	Response.Redirect("~/SomePage.aspx");
    	Response.End();
    }
    catch (System.Threading.ThreadAbortException)
    {
    	// Do nothing. This will happen normally after the redirect.
    }
    catch (System.Web.HttpException ex)
    {
    	if (ex.ErrorCode == unchecked((int)0x80070057)) //Error Code = -2147024809
    	{
    		// Do nothing. This will happen if browser closes connection.
    	}
    	else
    	{
    		throw ex;
    	}
    }
