c#
using Microsoft.AspNetCore.Mvc.ViewFeatures;
public static class HtmlHelperExtensions
{
    public static string GetExpressionText<TModel, TResult>(
        this IHtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TResult>> expression)
    {
        var expresionProvider = htmlHelper.ViewContext.HttpContext.RequestServices
            .GetService(typeof(ModelExpressionProvider)) as ModelExpressionProvider;
        return expresionProvider.GetExpressionText(expression);
    }
}
  [1]: https://github.com/aspnet/AspNetCore/issues/8678#issuecomment-475000503
