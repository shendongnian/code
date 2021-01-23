    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
    <div id="tabs">
    <%	
    	if (null != ViewData.TabListGet()) {
    		foreach(var item in ViewData.TabListGet()) {
    %>
    	<%= Html.ActionLink(item.Name, item.Action, item.Controller, item.RouteValues, null)%>
    <%		
    		}
    	}
    %>
    </div>
