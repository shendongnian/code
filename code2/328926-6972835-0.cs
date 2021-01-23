    public partial class ArticleHost : System.Web.UI.Page
    {
      protected void Page_Load(object sender, EventArgs e)
      {
        // ! Here we have access to url's parts and can redirect user for desired page via Server.Transfer method.
        var response = string.Format("culture: {0}<br/> article: {1}", Page.RouteData.Values["culture"], Page.RouteData.Values["article"]);
        Response.Write(response);
      }
    }
