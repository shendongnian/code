	private void addbtn_Click(object sender, EventArgs e)
	{
		try
		{
			persons p = new persons(); // we use a new instance of person class
			p.p_fname = this.fname.Text;
			p.p_lname = this.lname.Text;
			p.p_age = this.age.Text;
			p.p_gender = this.gender.Text;
			p.p_address = this.address.Text;
			d.add_data(p); // we save the instance of persons
			this.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show("Error : " + e);
		}
	}
	...
	class databasecon
	{
		public void add_data(person p) // we need a person as parameter
		{
			OleDbConnection con = new OleDbConnection();
			con.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=../dbsample.mdb";
			con.Open();
			try
			{
				OleDbCommand cmd = new OleDbCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.Text;
				// this is the correct sql command string
				cmd.CommandText = "INSERT INTO person(u_fname,u_lname,u_age,u_gender,u_address) " +
					VALUES (@u_fname, @u_lname, @u_age, @u_gender, @u_address)";
				cmd.Parameters.AddWithValue("u_fname", p.p_fname);
				cmd.Parameters.AddWithValue("u_lname", p.p_lname);
				cmd.Parameters.AddWithValue("u_age", p.p_age);
				cmd.Parameters.AddWithValue("u_gender", p.p_gender);
				cmd.Parameters.AddWithValue("u_address", p.p_address);
				cmd.ExecuteNonQuery();
			}
			finally
			{
				con.Close();
			}
		}
		
		...
	}
