	public static class YnnovaHtmlHelper
	{
		public static ClientSideValidationDisabler BeginDisableClientSideValidation(this HtmlHelper html)
		{
			return new ClientSideValidationDisabler(html);
		}
	}
	public class ClientSideValidationDisabler : IDisposable
	{
		private HtmlHelper _html;
	
		public ClientSideValidationDisabler(HtmlHelper html)
		{
			_html = html;
			_html.EnableClientValidation(false);
		}
		public void Dispose()
		{
			_html.EnableClientValidation(true);
			_html = null;
		}
	}
