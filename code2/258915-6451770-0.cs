        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            var builder = new TagBuilder("img");
            // Put some caching logic here if you want it to perform better
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            if (!File.Exists(helper.ViewContext.HttpContext.Server.MapPath(src)))
            {
                src = urlHelper.Content("~/content/images/none.png");
            }
            else
            {
                src = urlHelper.Content(src);
            }
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
