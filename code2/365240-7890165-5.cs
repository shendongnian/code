    <%@ Page 
        Language="C#" 
        MasterPageFile="~/Views/Shared/Site.Master" 
        Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Controllers.SystemRoleList>" 
    %>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <% using (Html.BeginForm()) { %>
            <%= Html.ListBoxFor(x => x., new SelectList(Model.List, "Id", "Name")) %>
            <button type="submit">OK</button>
        <% } %>
    
    </asp:Content>
