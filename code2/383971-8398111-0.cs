     protected void GdvDetails_DataBound(object sender, EventArgs e)
        {
            CheckBox chkItem = null;
            foreach (GridViewRow grRow in GdvDetails.Rows)
            {
                if (grRow.RowType == DataControlRowType.DataRow)
                {
                    chkItem = (CheckBox)grRow.Cells[6].FindControl("CkbActive");
                    bool bl = chkItem.Checked;
                    if (bl == false)
                    {
                      grRow.BackColor = Color.LightGray;
                    }
                }
            }
        }
