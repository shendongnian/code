    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Srl"
        DataSourceID="EntityDataSource1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Left.gif" CommandName="Add" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--Other columns--%>
        </Columns>
    </asp:GridView>
