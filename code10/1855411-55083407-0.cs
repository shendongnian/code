        private void button1_Click(object sender, EventArgs e)
        {
            //Find the radio button that is selected
            RadioButton rButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked == true);
            switch (rButton.Text)
            {
                case "Hamburger - $6.95":
                    subTotal = 6.95m;
                    break;
                case "Pizza - $5.95":
                    subTotal = 5.95m;
                    break;
                case "Salad - $4.95":
                    subTotal = 4.95m;
                    break;
            }
            //Add code to handle Add-on items
            //For example - The first check box is "Add Onions" - $0.50
            if (checkBox1.Checked)
                subTotal += .5m;
            lblSubTotal.Text = subTotal.ToString();
            decimal tax = subTotal * .0775m;
            lblTax.Text = tax.ToString();
            decimal total = subTotal + tax;
            lblTotal.Text = total.ToString();
        }
