    protected void Page_Load(object sender, System.EventArgs e)
    {
        string response = string.Empty;
        try
        {
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 36000;  //Timeout.Infinite, set timeout here
            WebResponse webResp = request.GetResponse();
            using (StreamReader reader = new StreamReader(webResp.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            response = "<font style='color:red'>Error:</font> \n" + ex.Message;
        }
        Response.Write(response);
    }
