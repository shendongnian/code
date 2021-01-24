        if(checkemail())
        {
            chkmail.Visible = true;
            mailerror.Text = "Email Address already Registered";
        }
        else if(checkuname())
        {
            chkuname.Visible = true;
            unameerror.Text = "Username is taken!";
        } 
        else
        {
            chkmail.Visible = false;
            chkuname.Visible = false;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Users values('" + fname.Text + "','" + lname.Text + "','" + email.Text + "','" + uname.Text + "','" + password.Text + "')";
            cmd.ExecuteNonQuery();
        }
