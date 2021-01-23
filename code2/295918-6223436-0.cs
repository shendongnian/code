using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Facebook;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
namespace fb
{
    public partial class test3 : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            FacebookApp fap = new FacebookApp();
            fap.AppId = "************";
            fap.AppSecret = "********************";
            string requested_Data = Request.Form["signed_request"];
            FacebookSignedRequest fsr = fap.ParseSignedRequest(requested_Data);
           // string json = JsonConvert.SerializeObject(fsr.Dictionary, Formatting.Indented);
            UserData ud = new UserData(fsr);
            Response.Write(ud.name + "<br>");
            Response.Write(ud.birthday + "<br>");
            Response.Write(ud.country + "<br>");
            Response.Write(ud.email + "<br>");
            Response.Write(ud.gender + "<br>");
            Response.Write(ud.location + "<br>");
            Response.Write(ud.userId + "<br>");
         
        }
      
    }
      
    public class UserData
    {
        public UserData(FacebookSignedRequest fsr)
        {
            string value = string.Empty;
            JObject o;
            foreach (string key in fsr.Dictionary.Keys)
            {
                value = fsr.Dictionary[key];
                switch (key)
                {
                    case "user_id":
                        userId = value;
                        break;
                    case "registration":
                        o = JObject.Parse(value);
                        name = GetValue(o, "name");
                        birthday = GetValue(o, "birthday");
                        email = GetValue(o, "email");
                        gender = GetValue(o, "gender");
                        location = GetValue(o, "location.name");
                        break;
                    case "user":
                        o = JObject.Parse(value);
                        country = GetValue(o, "country");
                        break;
                }
            }
            
        }
        private string GetValue(JObject o, string token)
        {
            string ret = string.Empty;
                       
            try
            {
                ret = (string)o.SelectToken(token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ret;
        }
     
        public string name { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string userId { get; set; }
      
    }
}
