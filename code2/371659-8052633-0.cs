	ClientContext clientContext = ClientContext.Current;
	if (clientContext == null)
	{
		SharepointUser = "[Unknown]";
	}
	else
	{
                try
                {
		MessageBox.Show("Beginning server query now...");
		clientContext.Load(clientContext.Web, s => s.CurrentUser);
		clientContext.ExecuteQueryAsync((s, e) =>
		{
			MessageBox.Show("RESPONSE!");
			SharepointUser = clientContext.Web.CurrentUser.LoginName;
			MessageBox.Show("Hello, " + SharepointUser + "!");
		},
		(s, e) =>
		{
			MessageBox.Show("An error occurred: " + e.ToString());
		});
                }
                catch (Exception err)
                {
                     MessageBox.Show("Synchronous error occurred: " + err.ToString());
                }
	}
