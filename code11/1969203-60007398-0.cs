`
protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink link = (HyperLink)e.Row.FindControl("lnk");
            if (link != null)
            {
                link.Visible = false;
            }
        }
    }
`
On your front-end, you need to add the event to the GridView....
`
<asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound">
</asp:GridView>
`
Here is also another example to get the DataItem for the GridView and then execute logic.  I created a sample ````MyProduct```` class, and imagine that the DataSource for my GridView is a Collection<MyProduct>(). 
`
    public partial class MyProduct
    {
        public string id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            MyProduct rowData = (MyProduct)e.Row.DataItem;
            if (rowData != null)
            {
                // only hide link if property for product meets our logic
                if (string.Equals(rowData.sku, "MySkuProduct", StringComparison.InvariantCultureIgnoreCase))
                {
                    HyperLink link = (HyperLink)e.Row.FindControl("lnk");
                    if (link != null)
                    {
                        link.Visible = false;
                    }
                }
            }
        }
    }
`
