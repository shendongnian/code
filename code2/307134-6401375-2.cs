    <%@ Page 
        Language="C#" 
        MasterPageFile="~/Views/Shared/Site.Master"
        Inherits="System.Web.Mvc.ViewPage<IEnumerable<AppName.Models.CanalViewModel>>" 
    %>
    <% using (Html.BeginForm()) { %>
        <%= Html.EditorForModel() %>
        <input type="submit" value="OK" />
    <% } %>
