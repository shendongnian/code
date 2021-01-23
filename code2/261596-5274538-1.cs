    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    public static MvcHtmlString NoAutoCompleteTextBoxFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
    {
        return html.TextBoxFor(expression, new { autocomplete="offd" });
    }
