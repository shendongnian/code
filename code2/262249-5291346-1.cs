    <%@ Page 
        Language="C#" 
        MasterPageFile="~/Views/Shared/Site.Master" 
        Inherits="System.Web.Mvc.ViewPage<AppName.Models.MyViewModel>" 
    %>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <h2>Progress</h2>
        <div><%= Html.DisplayFor(x = x.Progress)</div>
    </asp:Content>
