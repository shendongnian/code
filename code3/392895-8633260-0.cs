    private int _rowIndex=0;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) { 
                    e.Row.Cells[0].Text = _rowIndex.ToString();
                   _rowIndex++;
            }
        }
