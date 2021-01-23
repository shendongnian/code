    public static string Image<T>(this HtmlHelper helper, Expression<Action<T>> action, int width, int height, string alt)
				where T : Controller
		{
			var expression = action.Body as MethodCallExpression;
			string actionMethodName = string.Empty;
			if (expression != null)
			{
				actionMethodName = expression.Method.Name;
			}
			string url = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection).Action(actionMethodName, typeof(T).Name.Remove(typeof(T).Name.IndexOf("Controller"))).ToString();			
			//string url = LinkBuilder.BuildUrlFromExpression<T>(helper.ViewContext.RequestContext, helper.RouteCollection, action);
			return string.Format("<img src=\"{0}\" width=\"{1}\" height=\"{2}\" alt=\"{3}\" />", url, width, height, alt);
		}
    <%=Html.Image<ClassController>(c => c.Index(), 120, 30, "Current time")%>
