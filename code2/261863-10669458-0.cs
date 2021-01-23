    protected void LoginButton_Click(object sender, EventArgs e)
    {
        /****note: UserName and Password are textbox fields****/
                
        if (Membership.ValidateUser(UserName.Text, Password.Text))
        {
            MembershipUser user = Membership.GetUser(UserName.Text);
            if (user == null)
            {
               FailureText.Text = "Invalid username. Please try again.";
               return;
            }
            if (user.IsLockedOut)
               user.UnlockUser();
             
            /* this is the interesting part for you */
            if (user.LastPasswordChangedDate == user.CreationDate) //if true, that means user never changed their password before
            {
                //TODO: add your change password logic here
            }
        }
    }
