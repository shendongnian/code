    <asp:LinkButton id="btnYourLinkButton" runat="server" 
        OnClick="btnYourLinkButton_Click">Test</asp:LinkButton>
    protected void btnLogout_Click(object sender, System.EventArgs e)
    {
        var someObject = GetYourDataWithSomeFunction();
        Session["YourData"] = someObject;  // saves to session
        Response.Redirect("yourNewUrl.aspx");
    }
