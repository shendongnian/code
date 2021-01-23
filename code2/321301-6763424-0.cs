    public class SomeAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Some";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Some_default",
                "Some/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
