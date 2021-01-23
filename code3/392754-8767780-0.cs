    <%@ Import Namespace="System.Web.Routing" %>
    <%@ Application Language="C#" %>
    
    <script runat="server">
    
        void Application_Start(object sender, EventArgs e) 
        {
            RouteTable.Routes.MapPageRoute("default", string.Empty, "~/default.aspx");       
        }
