    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        AutoGenerateEditButton="True" DataKeyNames="ColPK" 
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ColPK" HeaderText="Column PK" 
                SortExpression="ColA" ReadOnly="True" />
            <asp:BoundField DataField="ColA" HeaderText="Column A" 
                SortExpression="ColA" />
            <asp:BoundField DataField="ColB" HeaderText="Column B" 
                SortExpression="ColB" />
            <asp:BoundField DataField="ColC" HeaderText="Column C" 
                SortExpression="ColC" />
        </Columns>
    </asp:GridView>
