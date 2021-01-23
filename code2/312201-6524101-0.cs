        using System.Web.Mvc.Html;
        public static MvcHtmlString MakeBoxGroup(this HtmlHelper Html, List<string> names)
        {
            string outStr = "";            
            foreach (string name in names)
                outStr += MakeBox(Html, name);
            return new MvcHtmlString(outStr);
        }
        public static MvcHtmlString MakeBox(HtmlHelper Html, string name)
        {
            return InputExtensions.CheckBox(Html,name);           
        }
