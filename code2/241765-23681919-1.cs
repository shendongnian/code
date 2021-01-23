    public static class EditorForExtentions
    {
        public static MvcHtmlString EditorFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, Object htmlAttributes, bool extendAttributes)
        {
            string value = html.EditorFor(expression).ToString();
            PropertyInfo[] properties = htmlAttributes.GetType().GetProperties();
            foreach (PropertyInfo info in properties)
            {
                int index = value.ToLower().IndexOf(info.Name.ToLower() + "=");
                if (index < 0)
                    value = value.Insert(value.Length - (value.EndsWith("/>") ? 2 : 1), info.Name.ToLower() + "=\"" + info.GetValue(htmlAttributes, null) + "\"");
                else if (extendAttributes)
                    value = value.Insert(index + info.Name.Length + 2, info.GetValue(htmlAttributes, null) + " ");            
            }
            return MvcHtmlString.Create(value);
        }
    }
