    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
      Inherits="System.Web.Mvc.ViewPage<IEnumerable<Category>>" %>
    <%@ Import Namespace="so_subcats.Model" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    	Categories
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <h2>Categories</h2>
    		<ul>
    		<% foreach (Category cat in Model)
    			 Html.RenderPartial("CategoryControl", cat); %>
    		</ul>
    
    </asp:Content>
