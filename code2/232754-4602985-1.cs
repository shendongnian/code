    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebUI.ViewModels.RegisterViewModel>" %>
    <% using (Html.BeginForm()) { %>
      <% foreach(string role in Model.Roles) { %>
        <input type="checkbox" name="Roles" value="<%: role %>" /> <%: role %>
      <% } %>
      <p><input type="submit" value="Register" /></p>
    <% } %>
