    gridView1.RowDataBound += new GridViewRowEventHandler(gridView1_RowDataBound);
    ...
    void gridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataView dataSource = (DataView)gridView1.DataSource;
            DataColumn imageUrlColumn = dataSource.Table.Columns["ImageUrl"];
            if (imageUrlColumn != null)
            {
                int index = imageUrlColumn.Ordinal;
                DataControlFieldCell cell = (DataControlFieldCell)e.Row.Controls[index];
                string imageUrl = cell.Text;
                cell.Text = GenerateThumbnailUrl(imageUrl);
            }
        }
    }
