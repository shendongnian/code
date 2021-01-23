    using System;
    using System.Linq.Expressions;
    using Microsoft.AspNet.Html.Abstractions;
    using Microsoft.AspNet.Mvc.ViewFeatures;
    public static class HtmlExtensions
    {
        public static IHtmlContent DescriptionFor<TModel, TValue>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            if (html == null) throw new ArgumentNullException(nameof(html));
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression, html.ViewData, html.MetadataProvider);
            if (modelExplorer == null) throw new InvalidOperationException($"Failed to get model explorer for {ExpressionHelper.GetExpressionText(expression)}");
            return new HtmlString(modelExplorer.Metadata.Description);
        }
    }
