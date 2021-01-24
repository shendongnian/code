    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="ApproveButton" runat="server">Approve</asp:LinkButton>
                    <asp:LinkButton ID="RejectButton" runat="server">Reject</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[0].Text.Equals("Cancelled"))
            {
                ((LinkButton)e.Row.FindControl("ApproveButton")).Enabled = false;
                ((LinkButton)e.Row.FindControl("RejectButton")).Enabled = false;
            }
        }
    }
