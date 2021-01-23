    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        var customer = new Customer();
        customer.InsertCustomer(CUSTOMER_ID,                // Provide a unique customer Id
                                TextboxFirstName.Text,      // Provider the control that holds the first name
                                TextboxLastName.Text,       // Provider the control that holds the last name
                                TextboxContactNumber.Text,  // Provider the control that holds the contact number
                                CreateUserWizard1.Email,    
                                CreateUserWizard1.UserName);
    }
