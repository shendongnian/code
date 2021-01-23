    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
              OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        <asp:TemplateField HeaderText="Example"
            <ItemTemplate>
            <asp:label ID="YourSpanToClick" runat="server" />
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
         {
            Label yourSpanToClick= (Label)e.Row.FindControl("YourSpanToClick");
            YourDataSrcRowObject rowObject= DataBinder.Eval(e.Row.DataItem) as YourDataSrcRowObject ;
            string js = String.Format("window.open('{0}');", "temp.aspx?Id=" + rowObject.Id)
            yourSpanToClick.Attributes.Add("onclick",js);
      
         }
    }
