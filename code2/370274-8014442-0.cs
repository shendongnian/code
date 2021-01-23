    <asp:GridView ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" ...>    
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SomeColumn") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            ...
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CommandName="Update" CommandArgument='<%# Container.ItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
