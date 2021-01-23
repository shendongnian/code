    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<System.DateTime?>" %>
    <%
        string value;
        if (Model.HasValue && Model.Value != DateTime.MinValue) 
            value = Model.Value.ToShortDateString();
        else 
            value = string.Empty;
    %>
    <%=Html.TextBox("", value) %>
