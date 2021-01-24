    public class ApplicationControllerBase : ControllerBase
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // use ViewResultBase, if you need logic for both full and partial views. Since you want to add info for the _Layout page, ViewResult is better.
            if (filterContext.Result is ViewResult viewResult)
            {
                // Give the ViewBag item a unique name, that will not be used elsewhere, so you don't overwrite anything by accident.
                // Use the data from ViewBag to populate your dropdown.
                viewResult.ViewBag.DropDownItems = GetDropDownItems(); // implement GetDropDownItems accordingly, preferrably with caching!
            }
            base.OnResultExecuting(filterContext);
        }
    }
