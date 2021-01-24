    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="pass" HeaderText="pass" SortExpression="pass" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button runat="server"  ID="deleteButton" OnClick="deleteButton_Click" Text="Delete"/>                    
                </ItemTemplate>
                <ItemTemplate>
                    <asp:Button runat="server" ID="editButton" OnClick="editButton_Click" Text="Edit"/>
                </ItemTemplate>
            </asp:TemplateField>            
        </Columns>
        <HeaderStyle CssClass="gridviewheader" />
        <RowStyle CssClass="gridviewrow" />
    </asp:GridView>
