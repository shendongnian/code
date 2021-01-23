    Public Class ProjectPage : System.Web.UI.Page
        public new bool IsPostBack()
        {
            return (Page.IsPostBack && Request.HttpMethod.ToUpper() == "POST");
        }
    End Class
