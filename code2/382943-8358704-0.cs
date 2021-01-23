    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <script runat="server" type="text/C#">
            public string Foo()
            {
                return "bar";
            }
        </script>
        
        <div><%= Foo() %></div>
    
    </asp:Content>
