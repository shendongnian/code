      protected void gv_research_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
    
                    if (e.CommandName == "editResearch")
                    {
    
                        txt_researchName.Text = gv_research.Rows[index].Cells[1].Text.TrimEnd();
    
                    }
                 
    
                }
                catch (Exception ee)
                {
                    string message = ee.Message;
               
                }
            }
