    protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {
    
            if (ChangePassword1.CurrentPassword == ChangePassword1.NewPassword)
            {
                Response.Redirect("ChangePassword.aspx");
                
            }
            //Label1.Text = "current and new passwords should not match";        
            Label1.Visible = false;
        }
