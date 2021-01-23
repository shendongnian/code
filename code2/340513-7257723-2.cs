     public class BasePage : System.Web.UI.Page
     {
        public WebUser CurrentUser
        {
            get 
            {
                WebUser currentUser = HttpContext.Current.Session["WHATEVERKEY"] as WebUser;
                if (currentUser == null)
                {
                   currentUser = new WebUser();//and do some processing
                   HttpContext.Current.Session["WHATEVERKEY"] = currentUser;
                }
                return currentUser;
            }
            set 
            { 
                HttpContext.Current.Session["WHATEVERKEY"]=value;
            }
        }
     }
