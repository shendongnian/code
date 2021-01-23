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
    
            context.MapRoute("Cms_default_with_language", "Cms/{lang}/{controller}/{action}/{id}", new
            {
                controller = "Home",
                action = "Index",
                id = UrlParameter.Optional,
                lang = "de",
            }, new { lang = "de|en" });
            context.MapRoute(
                "Cms_default",
                "Cms/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, lang = "de" }
            );
    
            }
        }
    }
