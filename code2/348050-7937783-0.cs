	public static class MyExtensions
	{
		[Obsolete]
		public static MvcHtmlString DisplayFor<TModel, DateTime>(this HtmlHelper<TModel> html, Expression<Func<TModel, DateTime>> expression)
		{
			return html.DisplayFor(expression);
		}
	}
