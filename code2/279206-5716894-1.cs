            public class CustomViewEngine : System.Web.Mvc.WebFormViewEngine
    {
        public CustomViewEngine()
        {
            base.ViewLocationFormats = new string[]
            {
              "~/MVC/Views/{1}/{0}.aspx",
              "~/MVC/Views/{1}/{0}.ascx",
              "~/MVC/Views/Shared/{0}.aspx",
              "~/MVC/Views/Shared/{0}.ascx"
            };
               base.PartialViewLocationFormats = new string[] {
             "~/MVC/Views/{1}/{0}.aspx",
              "~/MVC/Views/{1}/{0}.ascx",
              "~/MVC/Views/Shared/{0}.aspx",
              "~/MVC/Views/Shared/{0}.ascx"
            };
               base.MasterLocationFormats = new string[]
            {
              "~/MVC/Views/{1}/{0}.master",
              "~/MVC/Views/Shared/{0}.master"
            };
        }
    }
