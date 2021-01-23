        public static MvcHtmlString ToMvcHtmlString(this MvcHtmlString htmlString)
        {
            if (htmlString != null)
            {
                return new MvcHtmlString(HttpUtility.HtmlDecode(htmlString.ToString()));
            }
            return null;
        }
