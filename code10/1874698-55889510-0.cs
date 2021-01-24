    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="TOTAL QUALITY">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("QUALITY")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
in .cs file
protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        Label Label1 = (Label)e.Row.FindControl("Label1");
        if (DataBinder.Eval(e.Row.DataItem, "QUALITY").ToString().ToUpper() == "D" || DataBinder.Eval(e.Row.DataItem, "QUALITY").ToString().ToUpper() == "E")
        {
            Label1.Style.Add("text-decoration", "underline");
        }
    }
}
you can add some more css style to beautify label.
