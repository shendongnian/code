    using System.Web;
    public class CustomFormHandler : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
    
            context.Response.ContentType = "text/css";
            context.Response.Write("input[type=text]  { "};
            context.Response.Write(" width: " + Model.CmsConfiguration.cms_form_width + "px;");
            context.Response.Write("}"};
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
