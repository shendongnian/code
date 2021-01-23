    public class MyViewEngineWebForms : MyViewEngine
    {
        public override void SetSearchPaths()
        {
            base.MasterLocationFormats = new string[] { "~/Skins/{2}/Views/{1}/{0}.master", "~/Skins/{2}/Views/Shared/{0}.master" };
            base.ViewLocationFormats = new string[] { "~/Skins/{2}/Views/{1}/{0}.aspx", "~/Skins/{2}/Views/Shared/{0}.aspx", "~/Skins/Shared/Views/{0}.aspx" };
            base.PartialViewLocationFormats = new string[] { "~/Skins/{2}/Views/{1}/{0}.ascx", "~/Skins/{2}/Views/Shared/{0}.ascx", "~/Skins/Shared/PartialViews/{0}.ascx" };
            base.FileExtensions = new string[] { "aspx", "ascx", "master" };
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return new WebFormView(controllerContext, partialPath, null, base.ViewPageActivator);
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            return new WebFormView(controllerContext, viewPath, masterPath, base.ViewPageActivator);
        }
    }
