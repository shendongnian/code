    public static class HtmlExtensions
    {
        public static MvcHtmlString StudentImage(this HtmlHelper<StudentViewModel> htmlHelper)
        {
            var model = htmlHelper.ViewData.Model;
            var relativeImagePath = "~/uploads/foto_" + model.StudentID + ".jpg";
            var imagePath = htmlHelper.ViewContext.HttpContext.Server.MapPath(relativeImagePath);
            var image = new TagBuilder("img");
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            image.Attributes["src"] = urlHelper.Content("~/uploads/some_generic_image.jpg");
            image.Attributes["alt"] = model.FullName;
            image.Attributes["style"] = "height: 125px; width: 125px";
            if (File.Exists(imagePath))
            {
                image.Attributes["src"] = urlHelper.Content(relativeImagePath);
            }
            return MvcHtmlString.Create(image.ToString());
        }
    }
