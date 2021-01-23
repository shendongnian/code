        protected void CreatedUser(object sender, EventArgs e)
          {
                    TextBox userNameTextBox = (TextBox)CreateUserWizard1.CreateUserStep.ContentTemplateContainer.FindControl("UserName");
                    MembershipUser user = Membership.GetUser(userNameTextBox.Text);
                    FormsAuthentication.SetAuthCookie(userNameTextBox.Text, false);
                    Response.Redirect("viewBasket.aspx?action=news");
          }
