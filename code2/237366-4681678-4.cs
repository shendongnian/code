        public static MvcHtmlString MyCheckBoxFor<TModel>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, bool>> expression,
            string permission,
            object htmlAttributes
        )
        {
            if (permission == "foo bar")
            {
                // the user has the foo bar permission => render the checkbox
                return htmlHelper.CheckBoxFor(expression, htmlAttributes);
            }
            // the user has no permission => render a readonly checkbox
            var mergedHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            mergedHtmlAttributes["readonly"] = "readonly";
            return htmlHelper.CheckBoxFor(expression, mergedHtmlAttributes);
        }
    }
