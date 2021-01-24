    protected void GridViewPricing_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         int index = Convert.ToInt32(e.CommandArgument);
          GridViewRow gvRow = GridViewPricing.Rows[index];
         if (e.CommandName == "ButtonCommandName")
          {
              //Your Code here something like 
               gvRow.Cells[0].Text
    
          }
    }
