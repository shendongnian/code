    public static MvcHtmlString RadioButtonForEnum<TModel, TProperty>(
        this HtmlHelper<TModel> htmlHelper,
        Expression<Func<TModel, TProperty>> expression
    )
    {
        var metaData = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        var sb = new StringBuilder();
        var enumType = metaData.ModelType;
        foreach (var field in enumType.GetFields(BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public))
        {
            var value = (int)field.GetValue(null);
            var name = Enum.GetName(enumType, value);
            var label = name;
            foreach (DisplayAttribute currAttr in field.GetCustomAttributes(typeof(DisplayAttribute), true))
            {
                label = currAttr.Name;
                break;
            }
            var id = string.Format(
                "{0}_{1}_{2}",
                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                metaData.PropertyName,
                name
            );
            var radio = htmlHelper.RadioButtonFor(expression, name, new { id = id }).ToHtmlString();
            sb.AppendFormat(
                "<label for=\"{0}\">{1}</label> {2}",
                id,
                HttpUtility.HtmlEncode(label),
                radio
            );
        }
        return MvcHtmlString.Create(sb.ToString());
    }
