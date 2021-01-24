    protected void Repeater1_ItemCommand(Object Sender, RepeaterCommandEventArgs e) 
    {        
        var quantityTextBox = e.Item.FindControl("txtChangeQuantity") as TextBox;
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
