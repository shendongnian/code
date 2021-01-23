      protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IsApprove"));
                if (status == "pending")
                {
                  
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Yellow;
                }
                else if(status== "accept")
                {
                
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Green;
                }
                else if (status == "reject")
                {
                   
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.Red;
                }
            }
        }
