    [WebMethod(EnableSession = false)]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public void ongoingtrainingdetails(string UserName)
    {
        SqlCommand cmd = new SqlCommand("App_Service", con);
        try
        {
            var request = HttpContext.Current.Request;
            IEnumerable<string> headers = request.Headers.GetValues("X-Api-Key");
            var value = headers.FirstOrDefault();
            // Code
        }
        catch (Exception ex)
        {
            //Code
        }
        finally
        {
           //Code
        }
    }
     
