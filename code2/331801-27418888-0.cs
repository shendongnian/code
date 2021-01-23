    protected void grd_RowCreated(object sender, GridViewRowEventArgs e)
            {
                 if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                    e.Row.Cells[0].ColumnSpan = 7; // number of visible columns;
            }
