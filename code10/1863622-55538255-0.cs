    MySqlCommand cmd1 = conn.CreateCommand();
    cmd1.CommandType = CommandType.Text;
    cmd1.CommandText = ("select * from deposits where MemberID=@MemberID and DepositAmount=@DepositAmount and (DATE_FORMAT(DateDeposited,'%Y-%m-%d')= CURRENT_DATE())");
    cmd1.Parameters.AddWithValue("@Name", txtname.Text);
    cmd1.Parameters.AddWithValue("@Phone", txtphone.Text.ToString());
    cmd1.Parameters.AddWithValue("@DepositAmount", txtamount.Text.ToString());
    cmd1.Parameters.AddWithValue("@Rate", txtrate.Text.ToString());
    cmd1.Parameters.AddWithValue("@MemberID", lblmemberID.Text);
    //DataReader
    MySqlDataReader da;
    conn.Open();
    da = cmd1.ExecuteReader();
    if (da.Read())
    {
    string s;
    DateTime converted = Convert.ToDateTime(da["DateDeposited"]);
    s = converted.ToString("yyyy/MM/dd");
    if ( da["MemberID"].ToString()==lblmemberID.Text && da["DepositAmount"].ToString()== txtamount.Text.ToString()&& s.ToString()==dateTimePicker1.Value.Date.ToString("yyyy/MM/dd"))
    {
     MessageBox.Show("Deposit already recorded", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
    conn.Close();
    }
    }
