    TextBox UserNameTextBox =  (TextBox)CreateUserWizardStep2.ContentTemplateContainer.FindControl("UserName");
    SqlDataSource DataSource = (SqlDataSource)CreateUserWizardStep2.ContentTemplateContainer.FindControl("InsertExtraInfo");
    MembershipUser User = Membership.GetUser(UserNameTextBox.Text);
    object UserGUID = User.ProviderUserKey;
    DataSource.InsertParameters.Add("UserId", UserGUID.ToString());
    DataSource.Insert();
} 
