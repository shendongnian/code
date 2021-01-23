    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage"  %>
    <script language="C#" runat="server">
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (User.IsInRole("Admin"))
            {
                this.MasterPageFile = "~/Views/Shared/Site2.Master";
            }
            else
            {
                this.MasterPageFile = "~/Views/Shared/Site.Master";
            }
        }
    </script>
