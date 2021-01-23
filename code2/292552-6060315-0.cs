    //In application Session_Start, 
    Session["ReportCache"] = new Dictionary<string, ReportStatus>();
    
    public class ReportResults
    {
    }
    public class ReportStatus
    {
        public int PercentComplete = 0;
    }
    [WebMethod(EnableSessions = true)]
    ReportResults RunReport(string uniqueid)
    {
        ReportStatus status = new ReportStatus();
        Session["ReportStatus"].Add(uniqueid, status);
        //Start report
        for(int i = 0; i < 100000; ++i)
        {
            //update the report status
            status.PercentComplete = 100 * 100000 * i / 100000;
        }
        Session["ReportStatus"].Remove(uniqueid);
   
    }
    [WebMethod(EnableSessions=true)]
    public ReportStatus GetStatus(uniqueid)
    {
        try
        {
            return Session["ReportStatus"][uniqueid];
        }
        catch(Exception)
        {
            return null;
        }
    }
