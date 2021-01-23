	using System;
	using System.Linq.Expressions;
	using System.Text;
	using System.Web.Mvc;
	using System.Web.Mvc.Html;
	using System.Web.Routing;
	using Fasterflect;
	
	namespace StackOverflow.Mvc.Extensions
	{
		public static class HtmlExtensions
		{
			#region ActionImage
			// href image link
			public static string ActionImage( this HtmlHelper helper, string href, string linkText, object htmlAttributes,
			                                  string alternateText, string imageSrc, object imageAttributes )
			{
				var sb = new StringBuilder();
				const string format = "<a href=\"{0}\"{1}>{2}</a>";
				string image = helper.Image( imageSrc, alternateText, imageAttributes ).ToString();
				string content = string.IsNullOrWhiteSpace( linkText ) ? image : image + linkText;
				sb.AppendFormat( format, href, GetAttributeString( htmlAttributes ), content );
				return sb.ToString();
			}
			
			// controller/action image link
			public static string ActionImage( this HtmlHelper helper, string controller, string action, string linkText, object htmlAttributes,
			                                  string alternateText, string imageSrc, object imageAttributes )
			{
				bool isDefaultAction = string.IsNullOrEmpty( action ) || action == "Index";
				string href = "/" + (controller ?? "Home") + (isDefaultAction ? string.Empty : "/" + action);
				return ActionImage( helper, href, linkText, htmlAttributes, alternateText, imageSrc, imageAttributes );
			}
			
			// T4MVC ActionResult image link
			public static string ActionImage( this HtmlHelper helper, ActionResult actionResult, string linkText, object htmlAttributes,
			                                  string alternateText, string imageSrc, object imageAttributes )
			{
				var controller = (string) actionResult.GetPropertyValue( "Controller" );
				var action = (string) actionResult.GetPropertyValue( "Action" );
				return ActionImage( helper, controller, action, linkText, htmlAttributes, alternateText, imageSrc, imageAttributes );
			}		
			#endregion
			
			#region Helpers
			private static string GetAttributeString( object htmlAttributes )
			{
				if( htmlAttributes == null )
				{
					return string.Empty;
				}
				const string format = " {0}=\"{1}\"";
				var sb = new StringBuilder();
				htmlAttributes.GetType().Properties().ForEach( p => sb.AppendFormat( format, p.Name, p.Get( htmlAttributes ) ) );
				return sb.ToString();
			}		
			#endregion
		}
	}
		
