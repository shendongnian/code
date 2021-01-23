    public abstract class CommonControllerBase : Controller
    {
        protected override void ExecuteCore()
        {
            var culture = CultureInfo.CreateSpecificCulture("en-GB");
            var t = Thread.CurrentThread;
            t.CurrentCulture = culture;
            t.CurrentUICulture = t.CurrentCulture;
            base.ExecuteCore();
        }
    }
