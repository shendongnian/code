    bool success = false;
    int numAttempts = 0;
    do
    {
        string pwd = user.ResetPassword();
        if (user.ChangePassword(pwd, confirmPassword))
        {
            success = Membership.ValidateUser(user.UserName, pwd);
        }
        numAttempts++;
    } while(numAttempts < 5 && !success);
