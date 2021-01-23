    [WebService( ... )]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [GenerateScriptType(typeof(Group))]
    [GenerateScriptType(typeof(Instance))]
    public class WebService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession=true)]
        [ScriptMethod()]
        public bool Test(Item item) { ... }
    }
