    public ActionResult Index()
    {
        /*Credentials of a user that has access to SSRS*/
        string userid = "UserId";
        string password = "MyPassword";
        string domain = "MyDomain";
    
        string reportURL="http://ServerName/ReportServer?/ReportsFolder/ReportName&Parameter=UserName&rs:Command=Render&rs:Format=PDF";
    
        NetworkCredential nwc = new NetworkCredential(userid, password, domain);
    
        WebClient client = new WebClient();
        client.Credentials = nwc;
    
        Byte[] pageData = client.DownloadData(reportURL);
    
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);
        Response.BinaryWrite(pageData);
        Response.Flush();
        Response.End();
                
        //return View();
        }
