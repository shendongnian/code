     protected void btnResetPassword_Click(object sender, EventArgs e)
        {
    MembershipUser mu = Membership.GetUser(txtResetUserName.Text.Trim());
                if (mu != null)
                {
                    if (!mu.IsLockedOut)
                    {
                        string resetPassword = Membership.GeneratePassword(8, 1);
                        mu.ChangePassword(mu.ResetPassword(), resetPassword);
                        ListDictionary replaceList = new ListDictionary();
                        replaceList.Add("<%UserName%>", "Name of the user");
                        replaceList.Add("<%NewCode%>", resetPassword);
                        Utility fetch = new Utility();
                        fetch.SendMail(mu.Email, string.Empty, "User account " + txtResetUserName.Text.Trim() + " password reset to: " + resetPassword, fetch.MailBodyTemplate(replaceList, "ResetEmailTemplate"), null);
                   }
                }
    }
