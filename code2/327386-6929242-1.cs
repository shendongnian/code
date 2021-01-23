    linkbutton CommandArgument='<%# Eval("some_id") %>' 
    protected void linkButton_Click(object sender, EventArgs e)
    {
        
        LinkButton linkButton = (LinkButton) sender;           
        if (linkButton != null)
        {
            if (linkButton.CommandArgument != null)
            {
                ...some code...
            }
        }
                   
    }
