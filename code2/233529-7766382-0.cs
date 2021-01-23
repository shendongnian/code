    public static MvcHtmlString DecimalBoxFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, decimal?>> expression, string format, object htmlAttributes = null)
    {
        var name = ExpressionHelper.GetExpressionText(expression);
        var fullName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
    
        decimal? dec = expression.Compile().Invoke(html.ViewData.Model);
    
        // Here you can format value as you wish
        var value = dec.HasValue ? (!string.IsNullOrEmpty(format) ? dec.Value.ToString(format) : dec.Value.ToString())
                    : "";
    
        return html.TextBox(fullName, value, htmlAttributes);
    }
