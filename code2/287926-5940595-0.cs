    public static MvcHtmlString RequiredLabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
    {
        var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    
        string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
        string labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split('.').Last();
    
        if (metaData.IsRequired)
            labelText += "<span class=\"required-field\">*</span>";
    
        if (String.IsNullOrEmpty(labelText))
            return MvcHtmlString.Empty;
    
        var label = new TagBuilder("label");
        label.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
    
        label.InnerHtml = labelText;
        return MvcHtmlString.Create(label.ToString());
    }
