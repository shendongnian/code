    public abstract partial class BaseController : Controller
    {
    	public const string MessagesViewDataKey = "Base.Messages";
    	
    	protected override void OnActionExecuted(ActionExecutedContext filterContext) {
    		if (filterContext != null && filterContext.Controller != null && !filterContext.IsChildAction) {
    			filterContext.Controller.ViewData[MessagesViewDataKey] = Messenger.MessageQueues;
    		}
    
    		base.OnActionExecuted(filterContext);
    	}
    }
    
    // site.master
    <% if (ViewData[BaseController.MessagesViewDataKey] != null)
               Html.RenderPartial("DisplayTemplates/MessageList", ViewData[BaseController.MessagesViewDataKey]); %>
