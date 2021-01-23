     public class BasePage : System.Web.UI.Page
     {
        public WebUser CurrentUser
        {
            get 
            {
                currentUser = HttpContext.Current.Session["WHATEVERKEY"] as WebUser;
                if (currentUser == null)
                {
                   currentUser = new WebUser();//and do some processing
                   HttpContext.Current.Session["WHATEVERKEY"] = currentUser;
                }
                return currentUser;
            }
            set 
            { 
                currentUser = value; 
                HttpContext.Current.Session["WHATEVERKEY"]=value;
            }
        }
     }
