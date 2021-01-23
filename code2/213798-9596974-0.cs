private void LoginEmployees_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
{
	if (FormsAuthentication.Authenticate(LoginEmployees.UserName, LoginEmployees.Password))
	{	
		// Valid login
		e.Authenticated = true;
	}
	else
	{
		// Invalid login
		e.Authenticated = false;
	}
}
