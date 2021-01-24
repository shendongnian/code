    if (txt_password.Text == txt_cnfpw.Text)
    {
    MessageBox.Show(query);
    command.CommandText = query;
    command.ExecuteNonQuery();
    MessageBox.Show("Record Saved successfully");
    }
    
    
    else{
    MessageBox.Show("Password confirm password are not matching");
    txt_cnfpw.Focus();
    }
