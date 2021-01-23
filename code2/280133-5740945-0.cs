    protected void gv_CommDetails_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument); //Here you can get the index.
                    if (e.CommandName == "ViewSummary")
                    {
                       drp_Comm.Items.FindByValue(((HiddenField)gv_CommDetails.Rows[index].Cells[0].FindControl("hdn_CommCode")).Value).Selected = true;
                       txt_CommDescription.Text =gv_CommDetails.Rows[index].Cells[2].Text;
                    }
                   
                }
    
                catch (Exception ee)
                {
                    string message = ee.Message;
                }
    
            }
