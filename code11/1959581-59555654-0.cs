	foreach (var btn in buttons)
		cmd.CommandText = "select * from clientOrder where TodayDateToCompare='" + lblTodayDate.Text + " and service_time='" + btn.Text + "'";
	cmd.Connection = con;
	SqlDataReader rd1 = cmd.ExecuteReader();
	if (rd1.HasRows)
	{
		foreach (var btn in buttons)
		{
			btn.Enabled = false;
			btn.BackColor = System.Drawing.Color.Red;
		}
		con.Close();
	}
	
