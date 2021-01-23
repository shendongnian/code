    public abstract class BaseController : Controller
    {
        public const string NotificationKey = "_notification";
        protected string Notification
        {
            get
            {
                return ViewData[NotificationKey] as string;
            }
            set
            {
                ViewData[NotificationKey] = value;
            }
        }
    }
    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        protected string Notification
        {
            get
            {
                return ViewData[BaseController.NotificationKey] as string;
            }
        }
    }
