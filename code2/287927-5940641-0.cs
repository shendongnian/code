    namespace HelpRequest.Controllers.Helpers
    {
     
        public static class LabelExtensions
        {
            public static MvcHtmlString Label(this HtmlHelper html, string expression, string id = "", bool generatedId = false)
            {
                return LabelHelper(html,
                                   ModelMetadata.FromStringExpression(expression, html.ViewData),
                                   expression, "", id, generatedId);
            }
     
            [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
            public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string id = "", bool generatedId = false)
            {
                return LabelHelper(html,
                                   ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                                   ExpressionHelper.GetExpressionText(expression), displayOptions, id, generatedId);
            }
     
            //public static MvcHtmlString LabelForModel(this HtmlHelper html)
            //{
            //    return LabelHelper(html, html.ViewData.ModelMetadata, String.Empty);
            //}
     
            internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, string id, bool generatedId)
            {
                string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
                if (String.IsNullOrEmpty(labelText))
                {
                    return MvcHtmlString.Empty;
                }
                var sb = new StringBuilder();
                sb.Append(labelText);
                sb.Append("*");
     
                var tag = new TagBuilder("label");
                if (!string.IsNullOrWhiteSpace(id))
                {
                    tag.Attributes.Add("id", id);
                }
                else if (generatedId)
                {
                    tag.Attributes.Add("id", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName) + "_Label");    
                }
                
                tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
                tag.SetInnerText(sb.ToString());
     
                return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
            }
        }
    }
