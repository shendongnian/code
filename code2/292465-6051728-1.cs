    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
      Inherits="System.Web.Mvc.ViewPage<System.IO.DirectoryInfo[]>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
      Directories
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <table style='width: 10px; height: 10px; margin-left:100px'>
        <% foreach (var directory in Model)
          { %>
            <tr>
              <td>
                <%= Html.ActionLink(
                        directory.Name, "Index",
                        new RouteValueDictionary { { "path", directory.FullName } }) %>
              </td>
             </tr>
            <%
          }%>
      </table>
    </asp:Content>
