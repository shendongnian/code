	public static partial class HtmlExtensions
	{
		public static MvcHtmlString ClientIdFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression)
		{
			return MvcHtmlString.Create(
                  htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(
                      ExpressionHelper.GetExpressionText(expression)));
		}
	}
