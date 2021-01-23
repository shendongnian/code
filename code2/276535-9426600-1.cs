    [WebService(Namespace = "http://example.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [System.ComponentModel.ToolboxItem(false)]
    public class Service: System.Web.Services.WebService
    {
    
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public Result GetData()
        {
            User user = GetUser();
    
            if (user.LoggedIn)
            {
                return GetData();
            }
            else
            {
                Context.Response.Status = "403 Forbidden"; 
                //the next line is untested - thanks to strider for this line
                Context.Response.StatusCode = 403;
                //the next line can result in a ThreadAbortException
                //Context.Response.End(); 
                Context.ApplicationInstance.CompleteRequest(); 
                return null;
            }
        }
