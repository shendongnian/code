    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        var myGrid = sender as GridView;
        if (myGrid.Rows.Count > 0)
        {
            myGrid.UseAccessibleHeader = true;
            myGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
