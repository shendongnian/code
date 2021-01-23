    private void PlaceOrder_Click(object sender, EventArgs e)
    {
        //I am assuming PlaceOrderForm is the name of the class of your other form
        PlaceOrderForm frm = new PlaceOrderForm();
        //Initialize other properties and events,etc.
        //Then make its background color as selected by user
        if(selectedcolor != null) frm.BackColor = selectedcolor;
    }
