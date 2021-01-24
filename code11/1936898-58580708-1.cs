    private void NudQuantity1_ValueChanged(object sender, EventArgs e)
    {
        gbCheesePizza.Enabled = !(NudQuantity1.Value == 0)
        UpdateTotal();
    }
    private void NudQuantity2_ValueChanged(object sender, EventArgs e)
    {
        gbHamPizza.Enabled = !(NudQuantity2.Value == 0)
        UpdateTotal();
    }
    private void UpdateTotal()
    {
        Total = Convert.ToDouble(NudQuantity1.Value) * Price_CheesePizza;
        Total += Convert.ToDouble(NudQuantity2.Value) * Price_HamPizza;
        lblTotalBill.Text = $"{Total:C}";
    }
