    <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="checkRecords" runat="server" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckHeader" runat="server" onclick="Check_All(this);" />
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
