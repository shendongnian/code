    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IUserProfile>" %>
    <%    if (Request.IsAuthenticated && Model != null) { %>
        Welcome <b><%= Model.DisplayName %></b>!
        [ <%= Html.ActionLink("Log Off", "LogOff", "Auth") %> ]
    <%
    }
    else {
    %> 
        [ <%= Html.ActionLink("Log On", "Login", "Auth") %> ]
    <%
    } 
    %>
