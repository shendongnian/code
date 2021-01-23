    public double CalculateAmount( double cost )
    {
        double tva = 1.196;
        return cost * tva;
    }
    protected void ReservationForm()
    {
       double cost = ...where do we get cost from? a database, a previous form, ???
       double totalAmount = CalculateAmount(cost);
       ltrl_showText = "Total Amount is " + totalAmount;
    }
    
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        double cost = double.Parse( inp_ProductOrdered.Text ); // seems reasonable on a button click
        double totalAmount = CalculateAmount(cost);
        ltrl_previewText = "You ordered nameProduct at the price of " + totalAmount ;
    }
