	private void button2_Click(object sender, EventArgs e)
    {
		var authenticationService = new AuthenticationService(sqlcon);
		
		
        try
        {
			var user = authenticationService.AuthenticateUser(txtusername.Text, txtpassword.Text);
			
			if (user.Date.AddDays(90) < DateTime.UtcNow)
			{
				Changpassad obj2 = new Changpassad();
				this.Hide();
				obj2.Show();
				
				return;
			}
			
			if (user.IsAdmin)
			{
				calladmin obj = new calladmin(user);
				this.Hide();
				obj.Show();
			}
			else
			{
				Callcenter1 obj = new Callcenter1(user);
				this.Hide();
				obj.Show();
			}
		
		}
		catch (Exception)
        {
            MessageBox.Show("Invalid Login try checking Useraname Or Password !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
	}
	
