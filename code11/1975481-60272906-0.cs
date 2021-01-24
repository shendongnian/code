    public async Task<ActionResult> GetReportingData()
    {
        var theURL = "http://servername/Reports_DomainName/Pages/Report.aspx?ItemPath=%2fMQMS2_TST%2fReportTest&year=2019&rs:Format=PDF";
    
        try
        {
            WebClient Client = new WebClient();
            Client.Credentials = new NetworkCredential(@"username", "password");
    
            byte[] data = Client.DownloadData(theURL);
    
            return new FileContentResult(data, "PDF") { FileDownloadName = String.Format("SomeReport_{0}.pdf", DateTime.Now.ToString("yyyyMMddhhmmss")) };       
        }
        catch(Exception ex)
        {
            // do something
        }
    }
