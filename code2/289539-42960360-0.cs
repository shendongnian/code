        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //((TextBox)GridView1.HeaderRow.FindControl("tbProjNumInsert")).Text
                if (newMaxNum != null && newMaxNum.Length > 0)
                {                
               ((TextBox)e.Row.Cells[4].FindControl("tbProjNumInsert")).Text = newMaxNum;
               System.Diagnostics.Debug.WriteLine("GridView1_RowDataBound()...GridView1.Width !!!! " + ((TextBox)e.Row.Cells[4].FindControl("tbProjNumInsert")).Text + "........newMaxNum:" + newMaxNum);
                }
            }
        }
