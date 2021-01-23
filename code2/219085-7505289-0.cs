public static string CustomerHelper( this HtmlHelper<Models.MyModel> helper, ... )
{
    ISessionModel model = helper.ViewData.Model;
    var sessionKey = model.SessionKey;
    ...
}
