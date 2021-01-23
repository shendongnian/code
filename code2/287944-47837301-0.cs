    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    
    namespace WIPRO.Helpers
    {
        public static class Helpers
        {
            public static MvcHtmlString LabelForRequired<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string translatedlabelText, object htmlAttributes)
            {
                var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
    
                string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
                string labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split('.').Last();
    
                if (metaData.IsRequired)
                {
                    labelText = translatedlabelText + "<span class=\"required\" style=\"color:orange;\"> <span style=\"font-size: 0.4em; vertical-align: super;\" class=\"glyphicon glyphicon-asterisk\" data-unicode=\"270f\"></span></span>";
    
                }
                else
                {
                    labelText = translatedlabelText;
    
                }
    
                if (String.IsNullOrEmpty(labelText))
                    return MvcHtmlString.Empty;
    
                var label = new TagBuilder("label");
                label.Attributes.Add("for", helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
    
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(htmlAttributes))
                {
                    label.MergeAttribute(prop.Name.Replace('_', '-'), prop.GetValue(htmlAttributes).ToString(), true);
                }
    
                label.InnerHtml = labelText;
                return MvcHtmlString.Create(label.ToString());
    
            }
    
        }
    
    }
