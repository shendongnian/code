    public class AreasDemoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AreasDemo";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AreasDemo_default",
                "AreasDemo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
