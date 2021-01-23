    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button
        ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" />
       
    </div>
    </form>
     
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Add("KK",this.TextBox1.Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox1.Text = Session["KK"] as string;
    }
     
    
