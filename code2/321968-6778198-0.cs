    <asp:Repeater runat="server" ID="myRepeater">
        <ItemTemplate>
            <asp:Button runat="server" OnClick="Button_Click" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>' />
        </ItemTemplate>
    </asp:Repeater>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            // load users
            myRepeater.DataSource = users;
            myRepeater.DataBind();
        }
    }
    
    protected void Button_Click(object sender, EventArgs e)
    {
        // delete user
        Button button = sender as Button;
        button.Visible = false;
    }
