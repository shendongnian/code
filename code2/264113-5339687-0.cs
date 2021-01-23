    using System.Web.Mvc;
    
    namespace MyProject.Areas.Cms
    {
        public class CmsAreaRegistration : AreaRegistration
        {
            public override string AreaName
            {
                get
                {
                    return "Cms";
                }
            }
    
            public override void RegisterArea(AreaRegistrationContext context)
            {
    
                context.MapRoute(
                    "Cms_default",
                    "Cms/{controller}/{action}/{id}",
                    new { action = "Index", id = UrlParameter.Optional, lang="de" }
                );
                context.MapRoute("Cms_default with language", "{lang}/Cms/{controller}/{action}/{id}", new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                }, new { lang = "en|fr" });
    
            }
        }
    }
