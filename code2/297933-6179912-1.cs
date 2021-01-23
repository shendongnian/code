    private void btnCustomer_Click(object sender, EventArgs e)
    {
            this.customer = new Standard_Customer(txtName.Text, txtSurname.Text, 0);
            customer.Name = "Mark 1";
            customer.TotalAmount = 5;
            gbCustomer.Enabled = false;
            gbProduct.Enabled = true;
    
            set_info(customer.customerType(), customer.Name + " " + customer.Surname, customer.TotalAmount);
        }
