    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<myNameSpace.WebUI.Models.PublicationsListViewModel>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    	Publications : <%: Model.CurrentCategory ?? "All Publications" %>
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <% 
        foreach (var publication in Model.Publications)
        { 
           Html.RenderPartial("PublicationSummary", publication, ViewData); 
        } 
        %>
        <div class="pager">
            <%: Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new { page = x, category = Model.CurrentCategory }))%>
        </div>
    </asp:Content>
