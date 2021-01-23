    <div>
        <asp:GridView ID="MyGridView" runat="server" EnableModelValidation="true" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="MyWinButton" runat="server" OnCommand="MyWinButton_OnCommand" CommandName="Win" Text="Win" />
                        <asp:Label ID="MyStatusLabel" runat="server" Text='<%# Bind("text") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    public void MyWinButton_OnCommand(Object sender, CommandEventArgs e)
    {
        var label = ((Button)sender).Parent.FindControl("MyStatusLabel") as Label;
        label.Text = e.CommandName;        
    }
