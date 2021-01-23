        public static IDisposable BeginFieldPrefix<TModel>(this HtmlHelper<TModel> html,
            Expression<Func<TModel, object>> expression)
        {
            return BeginFieldPrefix(html, (LambdaExpression) expression);
        }
        internal static IDisposable BeginFieldPrefix(this HtmlHelper html, LambdaExpression expression)
        {
            return BeginFieldPrefix(html, html.GetName(ExpressionHelper.GetExpressionText(expression)));
        }
        public static IDisposable BeginFieldPrefix(this HtmlHelper html, string fieldPrefix)
        {
            var templateInfo = html.ViewData.TemplateInfo;
            string oldFieldPrefix = templateInfo.HtmlFieldPrefix;
            templateInfo.HtmlFieldPrefix = fieldPrefix;
            return Disposable.Create(() => templateInfo.HtmlFieldPrefix = oldFieldPrefix);
        }
        public static string GetName<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            return html.GetName(ExpressionHelper.GetExpressionText(expression));
        }
        public static string GetName(this HtmlHelper html, string expression)
        {
            return html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
        }
