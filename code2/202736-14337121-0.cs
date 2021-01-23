    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Int32>" %>
    <%
        string displayText;
    
        if (Model == 0)
        {
            displayText = "";
        }
        else
        {
            displayText = Model.ToString();
        }
    
    %>  
    
    <%= Html.TextBox("", displayText)%>
