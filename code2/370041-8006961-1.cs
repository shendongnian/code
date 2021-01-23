    // In controller...
    ViewBag.OpenDemoAccount = NameSpace.Models.ActionsMetadata.Translations.ContentsGroupHolder();
    // In view...
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <%
            OpenDemoAccount content = ViewBag.OpenDemoAccount;
        %>
