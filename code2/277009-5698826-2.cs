    public class QueryStringUrlController : Controller
    {
        public RedirectToRouteResult Redirect(long id, int page, string name,
            string controllerToRedirect, string actionToRedirect)
        {
            return RedirectToActionPermanent(actionToRedirect, controllerToRedirect, new { id = id, page = page, name = name });
        }
    }
