    c#
    
    public string kmlStuff = "";
        protected void Page_Load(object sender, EventArgs e) {
            kmlStuff= Server.HtmlEncode("]]>");
        }
    
    
    ASpx
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div id="errorM">
            <%=Server.HtmlDecode(kmlStuff) %>
        </div>
    </asp:Content>
