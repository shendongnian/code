    try
    {
    	...
    }
    catch (System.Net.WebException exc)
    {
    	if ((exc.Response is System.Net.HttpWebResponse) &&
    		(exc.Response as System.Net.HttpWebResponse).StatusCode == System.Net.HttpStatusCode.Unauthorized)
    		MessageBox.Show("401");
    	else
    		throw exc;
    }
