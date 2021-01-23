    void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dataSource = (DataTable)gridView1.DataSource;
            int index = dataSource.Columns["image"].Ordinal;
            DataControlFieldCell cell = (DataControlFieldCell)e.Row.Controls[index];
            string imageUrl = cell.Text;
            cell.Text = GenerateThumbnailUrl(imageUrl);
        }
    }
