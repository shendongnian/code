    <asp:UpdatePanel runat="server" UpdateMode="Always">
            <ContentTemplate>
                <asp:Image runat="server" ID="Image1" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ContentPlaceHolder ID="MainContent" runat="server">
        </asp:ContentPlaceHolder>
    public void SetImageUrl(string url)
    {
        Image1.ImageUrl = url;
    }
