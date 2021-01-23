    public static class HtmlHelperExtension
    {
        public static string RenderMessages(this HtmlHelper obj, ErrorManager.Type type = ErrorManager.Type.None, object htmlAttributes = null) 
        {
            var builder = new TagBuilder("ul");
            var errors = ErrorManager.GetErrors(type);
    
            // If there are no errors
            // Return empty string
            if (errors.Count == 0)
                return string.Empty;
    
            // Merge html attributes
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
    
            // Loop all errors
            foreach (var error in errors)
            {
                builder.InnerHtml += String.Format("<li class=\"{0}\"><span>{1}</span></li>",
                    error.ErrorType.ToString().ToLower(),
                    error.Value as string);
            }
    
            return builder.ToString();
        }
    }
