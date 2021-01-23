    // In Server Side code
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.GetPostBackEventReference(hiddenButton);
    }
    // Javascript
    function SetSaved() {
        __doPostBack("<%= hiddenButton.UniqueID %>", "OnClick");
    }
    // ASP
     <asp:Button ID="hiddenButton" runat="server" OnClick="btnSaveGroup_Click" Visible="false"/>
