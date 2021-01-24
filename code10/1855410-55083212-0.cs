        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // only ONE of these can be checked, so "else if" is used
            if (rdoBurger.Checked)
            {
                subtotal = 6.95m;
            }
            else if (rdoPizza.Checked)
            {
                subtotal = 5.95m;
            }
            else if (rdoSalad.Checked)
            {
                subtotal = 4.95m;
            }
            // multiple of these could be checked, so only "if" is used
            if (checkBox1.Checked)
            {
                subtotal = subtotal + 100.00m; // whatever this item costs
            }
            if (checkBox2.Checked)
            {
                subtotal = subtotal + 4.99m; // whatever this item costs
            }
            if (checkBox3.Checked)
            {
                subtotal = subtotal + 10.99m; // whatever this item costs
            }
            // compute the tax and the total:
            salesTax = subtotal * 0.0775m;
            orderTotal = subtotal + salesTax;
            // output it to your labels/textboxes?
            lblSubtotal.Text = "$" + subtotal.ToString("F2");
            lblSalesTax.Text = "$" + salesTax.ToString("F2");
            lblOrderTotal.Text = "$" + orderTotal.ToString("F2");
        }
