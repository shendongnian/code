    private void btnNew_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Table("FirstName","LastName","Address") values ('" + txtFirstName.Text + "', '" + txtLastName.Text + "', '" + txtAddress.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Member added successfully");
        }
