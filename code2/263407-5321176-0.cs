		if (FormsAuthentication.Authenticate(txtUser.Text, txtPassword.Text))
		{
				switch (txtUser.Text)
				{
						case "alice":
								Response.Redirect("form1.aspx");
								break;
						case "bob":
								Response.Redirect("form2.aspx");
								break;
						default:
								FormsAuthentication.RedirectFromLoginPage(txtUser.Text, false);
								break;
				}
		}
