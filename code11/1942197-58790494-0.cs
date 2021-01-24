    // This is pseudo-code; you will need to substitute your actual
    // collections when you make them.
    private void num_ValueChanged(object sender, EventArgs e) {
        decimal total = 0;
        foreach (var product in products) {
            // Get numeric up-down for product
            var numUpDown = ...
            total += Convert.ToInt32(numUpDown.Value) * product.Price;
        }
        lblTotal.Text = total.ToString("C");
    }
