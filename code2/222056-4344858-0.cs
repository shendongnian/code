    if(lblMessage.Text != string.Empty)
    {
        //Function call for binding the dropdown with all DB names 
        BindDBDropDown();
        //Function call for binding the operation names in dropdown 
        SetOperationDropDown();
    }
    else
    {
        //Else give the error message to user
        lblMessage.Text = "Invalid Credentials";
    }
