        foreach (GridViewRow row in GridView1.Rows) 
        {
          if(row.RowType == DataControlRowType.DataRow)
          { 
            CheckBox cb = (CheckBox)row.FindControl("ProductSelector"); 
            if (cb != null && cb.Checked)
            { 
                atLeastOneRowDeleted = true; 
                int productID = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value); 
                Response.Write(string.Format( "This would have deleted ProductID {0}<br />", productID));
            }
          }
        }
