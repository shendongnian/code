    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="gridView_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Column1" DataField="Column1" />
            <asp:BoundField HeaderText="Column2" DataField="Column2" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblStatus" Text='<%#Bind("Status") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkAction" runat="server">Approve</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var status = (e.Row.FindControl("lblStatus") as Label).Text;
            if (status == "Cancelled")
            {
                (e.Row.FindControl("lnkAction") as LinkButton).DisableControl("Disabled button.");
            }
        }
    }
