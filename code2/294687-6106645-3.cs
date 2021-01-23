    <%@ Page Title="" 
             Language="C#" 
             MasterPageFile="~/Views/Shared/Site.Master" 
             Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication3.Models.Question>>" 
    %>
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
        Details
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <table>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                </tr>
            </thead>
            <tbody>
                <%= Html.DisplayForModel() %>
            </tbody>
        </table>
    </asp:Content>
