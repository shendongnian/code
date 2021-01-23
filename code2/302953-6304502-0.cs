    private void GetRSS()
    {
        WebRequest rssReq = WebRequest.Create("URL");
        //Create a Proxy
        WebProxy px = new WebProxy("URL", true);
        //Assign the proxy to the WebRequest
        rssReq.Proxy = px;
        //Set the timeout in Seconds for the WebRequest
        rssReq.Timeout = 5000;
        try
        {
            //Get the WebResponse
            WebResponse rep = rssReq.GetResponse();
            //Read the Response in a XMLTextReader
            XmlTextReader xtr = new XmlTextReader(rep.GetResponseStream());
            //Create a new DataSet
            DataSet ds = new DataSet();
            //Read the Response into the DataSet
            ds.ReadXml(xtr);
            //Bind the Results to the Repeater
            rssRepeater.DataSource = ds.Tables[0];
            rssRepeater.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
