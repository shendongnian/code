    <asp:UpdatePanel ID="up1" runat="server" UpdateMode="Conditional">
    protected void ImageButton1_Command(object sender, EventArgs e)
    {
       up1.Update();
       string targetPage = "..."
       ((ImageButton)sender).Attributes.Add("onclick", targetPage);
    }
