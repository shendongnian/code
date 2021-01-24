    List<string> orders = new List<string>();
    private void chkHamburger_CheckedChanged(object sender, EventArgs e)
    {
        txtHamburger.Enabled = chkHamburger.Checked;
        if (chkHamburger.Checked)
        {
            txtHamburger.Text = "";
            txtHamburger.Focus();
            orders.Add("Hamburger");
        }
        else
        {
            txtHamburger.Text = "0";
            orders.Remove("Hamburger");
        }
        UpdateOrders();
    }
    private void chkCheeseBurger_CheckedChanged(object sender, EventArgs e)
    {
        txtCheeseBurger.Enabled = chkCheeseBurger.Checked;
        if (chkCheeseBurger.Checked)
        {
            txtCheeseBurger.Text = "";
            txtCheeseBurger.Focus();
            orders.Add("Cheese Burger");
        }
        else
        {
            txtCheeseBurger.Text = "0";
            orders.Remove("Cheese Burger");
        }
        UpdateOrders();
    }
    private void UpdateOrders()
    {
        txtOrders.Text = string.Join(Environment.NewLine, orders);
    }
