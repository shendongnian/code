    public class ServeController: Controller
    {
        public ContentResult GetCss(string id)
        {
            string cssBody = GetCssBodyFromDatabase(id);
            return Content(cssBody, "text/css");
        }
    }
