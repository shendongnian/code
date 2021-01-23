    protected void btnComplete_Click(object sender, EventArgs e)    
    {  
         Button btn = (Button)sender;
         GridViewRow gvRow = (GridViewRow)btn.Parent.Parent;
         
         Label lblComments = (Label)gvRow.FindControl("lblComments");
         
         // lblComments.Text ...whatever you wanted to do
    }
