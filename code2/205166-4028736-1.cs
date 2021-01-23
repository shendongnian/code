	public class NotEqualConstraint : IRouteConstraint
	{
		private string match = String.Empty;
		public NotEqualConstraint(string match)
		{
			this.match = match;
		}
		public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
		{
			return String.Compare(values[parameterName].ToString(), match, true) != 0;
		}
	}
