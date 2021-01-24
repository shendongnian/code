    int priceTotal;
    if (!string.IsNullOrEmpty(orderTotal.Text))
    {
        priceTotal = Convert.ToInt32(orderTotal.Text);
    }
    else
    {
        priceTotal = 0;
    } 
