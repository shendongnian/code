       protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
            {
    
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);//Get the index
    
                    if (e.CommandName == "Select_ad")
                    {
                     
                      int id =int.Parse(GridView1.Rows[index].Cells[4].Text);   
                      //your code
                       
                    }
                }
    
    
                catch (Exception ee)
                {
                    string message = ee.Message;
                }
            }
