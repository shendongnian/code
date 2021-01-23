    public class UpdateDataset : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        AppointmentsWS.WebServiceConsumerClient objApp = new AppointmentsWS.WebServiceConsumerClient();
        DataSet ds = new DataSet();
        ds = objApp.ScheduleGridSource();
        context.Session["AppDetails"] = ds;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
