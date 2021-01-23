    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<YourNamespace.YourModel>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
        Create
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% using (Html.BeginForm("AddEvent", "YourControllerName", FormMethod.Post, new { id = "create_event" }))
         { %>
        <h2>Create</h2>
        <p>Event ID: <%= Html.TextBox("txtEventID", Model.txtEventID)%> </p>
        <p>Event Description: <%= Html.TextBox("txtEventDescription", Model.txtEventDescription)%> </p>
        <button id="submit">Add Event</button>
      <% } %>
    </asp:Content>
