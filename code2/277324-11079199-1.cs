    public static class FormatHelper
    {
    	public static IHtmlString ToDate( this HtmlHelper helper, DateTime datetime )
        {
            return new HtmlString( datetime.ToShortDateString() );
    	}
    }
