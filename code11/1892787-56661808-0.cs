    public class CommonViewBagInitializerActionFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            ((Controller)context.Controller).ViewBag.MainLayoutViewModel = new MainLayoutViewModel() {
                PageTitle = "MyTitle"
        };
        }
    }
