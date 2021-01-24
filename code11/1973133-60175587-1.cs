     public class DeshboardController : Controller
        {
            // GET: Admin
            public ActionResult Index()
            {
                string roleid = (string)Session["user_role_id"];
                string userid = (string)Session["user_au_id"];
                string companyId = (string)Session["company_id"];
                string accessToken = (string)Session["AccessToken"];
                string ConName = "Deshboard";
                string ActionName = "index";
    
                if (string.IsNullOrEmpty(roleid) || string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(companyId))
                {
                    Response.Redirect("/Login/Index");
                }
                bool permission = CoreRules.UserPermission(roleid, userid, ConName, ActionName, accessToken);
                if (!permission)
                {
                    try
                    {
                        Response.Redirect("/Error/Index");
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("/Login/Index");
                    }
                }
    
            
                return View();
            }
        }
