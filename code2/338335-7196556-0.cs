        public static MvcHtmlString CheckBoxStringFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, string>> expression)
        {
            // get the name of the property
            string[] propertyNameParts = expression.Body.ToString().Split('.');
            string propertyName = propertyNameParts.Last();
            // get the value of the property
            Func<TModel, string> compiled = expression.Compile();
            string booleanStr = compiled(html.ViewData.Model);
            
            // convert it to a boolean
            bool isChecked = false;
            Boolean.TryParse(booleanStr, out isChecked);
            TagBuilder checkbox = new TagBuilder("input");
            checkbox.MergeAttribute("id", propertyName);
            checkbox.MergeAttribute("name", propertyName);
            checkbox.MergeAttribute("type", "checkbox");
            checkbox.MergeAttribute("value", "true");
            if (isChecked)
                checkbox.MergeAttribute("checked", "checked");
            TagBuilder hidden = new TagBuilder("input");
            hidden.MergeAttribute("name", propertyName);
            hidden.MergeAttribute("type", "hidden");
            hidden.MergeAttribute("value", "false");
            return MvcHtmlString.Create(checkbox.ToString(TagRenderMode.SelfClosing) + hidden.ToString(TagRenderMode.SelfClosing));
        }
