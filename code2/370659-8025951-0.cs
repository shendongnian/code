    void FindUserOrRegister()
    {
        User user = GetUserFromDatabase();
        if (user != null)
        {
            new MainApplicationForm(user).Show();
        }
        else
        {
            new RegistrationForm().Show();
        }
    }
