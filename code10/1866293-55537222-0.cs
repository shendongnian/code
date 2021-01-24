csharp
private void btnSave_Click(object sender, EventArgs e) {
    var error = string.Empty;    
    if(ValidatePassword(txtPassword.Text, error))
    {
        var data = DBConnection.DBConnect();
        SqlCommand cmd = new SqlCommand("Insert_Users", data);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@StaffName", SqlDbType.VarChar).Value = txtStaffName.Text;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = txtUsername.Text;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text;
        cmd.Parameters.Add("@Phoneno", SqlDbType.NVarChar).Value = txtPhoneNo.Text;
        cmd.Parameters.Add("@Admin", SqlDbType.Char).Value = chkIsAdmin.CheckState == CheckState.Checked ? 1 : 0;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        MessageBox.Show("Saved Sucessfully");
        LoadUsers();
    }
    else
    {
        throw new Exception(error); // Or Console.WriteLine(error) or whatever
    }
}
