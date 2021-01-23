    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<InnVue.Globe.Models.CategoryModel>" %>
        <%@ Import Namespace="InnVue.Globe.Models" %>
    
        <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
            <%: ViewContext.RouteData.Values["Action"] %> Category
        </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <h2><%: ViewContext.RouteData.Values["Action"] %> Category</h2>
    
        <% Html.EnableClientValidation(); %>
        <% using (Html.BeginForm()) {%>
            <%: Html.ValidationSummary(true) %>
    
            <fieldset>
                <legend>CategoryDescription</legend>
                <% foreach (var catdes in Model.CategoryDescriptions) { %>
                    <% Html.RenderPartial("CategoryDescriptions", catdes); %>
                <% } %>
                <p>
                    <input type="submit" value="Save" />
                </p>
            </fieldset>
        <% } %>
    
        <div>
            <%: Html.ActionLink("Back to List", "Index") %>
        </div>
    
    </asp:Content>
