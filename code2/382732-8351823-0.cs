    namespace ProjectName.HtmlHelpers
    {
        public static class DisplayHelpers
        {
            public static MvcHtmlString GetTags()
            {
                var tags = from tag in model.Tags select tag;
                StringBuilder sb = new StringBuilder();
                foreach (Tag tag in tags)
                {
                    sb.AppendFormat("<a href="{0}"> {1} </a>",
                         // link,
                         tag.Name);
                }
                return new MvcHtmlString(sb.ToString());
            }
        }
    }
