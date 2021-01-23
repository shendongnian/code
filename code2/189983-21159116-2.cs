    try
    {
    	...
    }
    catch (System.Net.WebException exc)
    {
        var webResponse = exc.Response as System.Net.HttpWebResponse;
    	if (webResponse != null && 
            webResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
    		MessageBox.Show("401");
        }
    	else
    		throw;
    }
