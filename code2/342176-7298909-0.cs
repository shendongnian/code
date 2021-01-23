    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label NewLabel = new Label();
        NewLabel.Text = "Hello World!";
        PlaceHolder1.Controls.Add(NewLabel); 
    }
