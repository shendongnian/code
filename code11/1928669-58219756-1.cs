		protected void txtEmployeeNumber_TextChanged(object sender, EventArgs e)
		{
			string EmployeeNo = "";
			string constring = ConfigurationManager.ConnectionStrings["SQLDBConnection"].ConnectionString;
			SqlConnection con = new SqlConnection(constring);
			
			foreach (GridViewRow row in grdRegister.Rows)
			{
				if (row.RowType == DataControlRowType.DataRow)
				{
					EmployeeNo = (row.Cells[1].FindControl("txtEmployeeNumber") as TextBox).Text;
				}
				SqlCommand cmd = new SqlCommand("select Employee_Name from [138.201.225.134].[iProfile].[dbo].[tbl_Employee] WHERE Personnel_Number= @Personnel_Number", con);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@Personnel_Number", EmployeeNo);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				if (dt.Rows.Count > 0)
				{
					(row.Cells[2].FindControl("txtEmployeeName1") as TextBox).Text = dt.Rows[0]["Employee_Name"].ToString();
				}
			}
		}
