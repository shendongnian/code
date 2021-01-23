    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Category>" %>
    <%@ Import Namespace="so_subcats.Model" %>
    <li><%= Model.Name %>
    	<% if (Model.Subcategories != null) { %>
    		<ul>
    		<% foreach (Category subcat in Model.Subcategories)
    			 Html.RenderPartial("CategoryControl", subcat); %>
    		</ul>
    	<% } %>
    </li>
