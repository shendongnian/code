    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
    <%@ Import Namespace="System.Web.Mvc.Html" %>
    <%
        string displayText = string.Empty;
        if (Model != null)
        {
            displayText = Model.ToString();
        }
        
    %>
    <%= Html.TextBox("", displayText)%>
