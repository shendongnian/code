    public class SessionManager : System.Web.UI.Page
    {
        public MyUser SessionUser
        {
            get
            {
                return (MyUser) Session["User"];
            }
            set
            {
                Session["User"] = value;
            }
        }
    }
