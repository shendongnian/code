    <form id="form1" runat="server">
    
        <div>
            <asp:Label ID="Message" runat="server" Text=""></asp:Label>
        </div>
        
        <asp:Button ID="Button1" runat="server" Text="Button 1" OnClick="Button1_Click" /> - 
        <asp:Button ID="Button2" runat="server" Text="Button 2" OnClick="Button2_Click" />
    
    </form>
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Message.Text = "Button 1 clicked";
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Message.Text = "Button 2 clicked";
    }
