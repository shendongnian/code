    public class User{
      public Int32 UserId{
        get;set;
      }
    }
    [System.Web.Script.Services.ScriptMethod]  
        [System.Web.Services.WebMethod]  
        public static void GenerateUserSchedules(string startDate, string endDate, string ddlViewSelectedItem, string ddlViewSelectedValue, string ddlOrgSelectedValue, User[] customObejct) 
