    public void verif()
    {
        StringBuilder errorBuilder = new StringBuilder();
        
        if (string.IsNullOrWhiteSpace(inputUserName.text))
        {
            errorBuilder.AppendLine("UserName cannot be empty!");
        }
        if (string.IsNullOrWhiteSpace(inputEmail.text))
        {
            errorBuilder.AppendLine("Email cannot be empty!");
        }
        // Add some more validation if you want, for instance you could also add name length or validate if the email is in correct format
        if (errorBuilder.Length > 0)
        {
            print(errorBuilder.ToString());
            return;
        }
        else // no errors
        {
            CreateUser();
        }
    }
