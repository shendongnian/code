        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CMS.SiteProvider.UserInfo ui = CMS.SiteProvider.UserInfoProvider.AuthenticateUser(txtEmail.Text, txtPassword.Text, CMS.CMSHelper.CMSContext.CurrentSite.SiteName);
            if (ui != null)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(ui.UserName, true);
                CMS.CMSHelper.CMSContext.SetCurrentUser(new CMS.CMSHelper.CurrentUserInfo(ui, true));
                CMS.SiteProvider.UserInfoProvider.SetPreferredCultures(ui);
                Response.Redirect("MY_SECURE_PAGE");
            }
            else
            {
                litMessage.Text = "Email/Password incorrect";
            }
        }
