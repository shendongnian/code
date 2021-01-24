    try
    {
        if (txtName.Text.Length < 0)
        {
            throw new ValidationException("Please enter user name")
        }
        // ...
    }
    catch(ValidationException ex)
    {
        MessageBox.Show(ex.Message);
    }
