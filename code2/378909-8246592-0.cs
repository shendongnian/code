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
            return new Disposable(() => templateInfo.HtmlFieldPrefix = oldFieldPrefix);
        }
