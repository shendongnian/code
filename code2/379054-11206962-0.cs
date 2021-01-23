    private bool loginSharePoint()
        {
            lbLoginStatus.Text = "Logging in Sharepoint server";
            bool isValid = false;
            //validating Sharepoint login
            string spUsername = tbSharePointUsername.Text;
            string spPassword = tbSharePointPassword.Text;
            pc = new PrincipalContext(ContextType.Domain, spUsername.Split('\\')[0]);
            pbLogin.PerformStep();
            // validate the credentials
            isValid = pc.ValidateCredentials(spUsername.Split('\\')[1], spPassword);
            if (isValid)
            {
                pbLogin.PerformStep();
                pbLogin.PerformStep();
                site = new SPSite(tbSharePointUrl.Text);
                pbLogin.PerformStep();
                web = site.OpenWeb();
                pbLogin.PerformStep();
                if (web.DoesUserHavePermissions(spUsername, SPBasePermissions.Open))
                    isValid = true;
                else
                    isValid = false;
            }
            return isValid;
        }
