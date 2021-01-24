    public class BasePageModel : PageModel
    {
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //...
        }
    }
    public class IndexModel : BasePageModel
    {
        public void OnGet()
        {
            //...
        }
    }
