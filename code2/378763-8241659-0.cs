    using System;
    using System.Linq.Expressions;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using Authentication;
    public static class LinkExtensions
    {
        // Named thusly to avoid conflict, I anticipate a search-and-replace later!
        public static MvcHtmlString ActionLink5<TController>(this HtmlHelper helper, Expression<Action<TController>> action, string linkText, object htmlAttributes) where TController : Controller
        {
            RouteValueDictionary routeValuesFromExpression = Microsoft.Web.Mvc.Internal.ExpressionHelper.GetRouteValuesFromExpression<TController>(action);
            return helper.RouteLink(linkText, routeValuesFromExpression, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }
    }
