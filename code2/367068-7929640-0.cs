    public static class HtmlExtensions
    {
        public static bool IsValid<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression
        )
        {
            var modelState = htmlHelper.ViewData.ModelState;
            var name = ExpressionHelper.GetExpressionText(expression);
            var key = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState value;
            return !modelState.TryGetValue(key, out value) || 
                   value.Errors.Count == 0;
        }
    }
