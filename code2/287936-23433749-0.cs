    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Linq.Expressions;
    using System.ComponentModel;
    
	public static class RequiredLabel
	{
		public static MvcHtmlString RequiredLabelFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
		{
			var metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
			string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
			string labelText = metaData.DisplayName ?? metaData.PropertyName ?? htmlFieldName.Split('.').Last();
			if (metaData.IsRequired)
				labelText += "<span class=\"required\">*</span>";
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
