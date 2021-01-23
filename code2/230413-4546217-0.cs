    [WebService(Namespace = "http://www.mysite.com/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class UpVote : IHttpHandler
    {  public void ProcessRequest(HttpContext context)
        { 
           // Create this method to deal with your database
           MakeUpVote(context.Request["commentID"].tostring());   // Comment ID is the input
    } }
