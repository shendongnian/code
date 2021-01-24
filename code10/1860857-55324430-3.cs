    protected void gvInventatario_RowCommand(Object Sender, GridViewCommandEventArgs e) 
    {   
        GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        
        TextBox quantityTextBox = row.FindControl("MyTextBoxId") as TextBox;
    
        if(quantityTextBox != null)
        {
            int resultingQuantity = 0;
            if (drOperation.Text == "-")
            {
                resultingQuantity = quantity - int.Parse(quantityTextBox.Text);
            }
            else
            {
                resultingQuantity = quantity + int.Parse(quantityTextBox.Text);
            }
           
            if (resultingQuantity > 0)
            {
            }
        }
    }
