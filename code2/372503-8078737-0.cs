    private enum MENU_ITEM
    { 
        Customer_ID = 0,
        Customer_First_Name = 1,
        Customer_Surname = 2,
        Customer_DOB = 3,
        Customer_Phone_Number = 4,
        Customer_Email = 5,
        Customer_Update = 6,
        Customer_Delete = 7,
        Customer_Transaction = 8
    }
    private void populateGridHeader()
    {
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_ID].Visible = false;
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_First_Name].HeaderText = "First Name";
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_Surname].HeaderText = "Surname";
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_DOB].HeaderText = "Date of Birth";
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_Phone_Number].HeaderText = "Phone Number";
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_Email].HeaderText = "Email";
        SearchCustomer_g.Columns[(int)MENU_ITEM.Customer_Transaction].HeaderText = "New Transaction";
    }
