    protected void Sorting(object sender, GridViewSortEventArgs e)
    {
        Label label = new Label();
        label.Text = gv_s.Rows.Count.ToString() + " records";
        ((GridView)sender).FooterRow.Cells[0].Controls.Add(label);
    }
