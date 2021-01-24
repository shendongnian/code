    string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
    SqlConnection sqlconn = new SqlConnection(mainconn);
    string sqlquery = "insert into [signup] values (@charactername,@characterid,@email,@phonenumber)";
    sqlconn.Open();
    SqlCommand cmd = new SqlCommand(sqlquery, sqlconn);
    cmd.Parameters.AddWithValue("@charactername", txtcharactername.Text);
    cmd.Parameters.AddWithValue("@characterid", txtcharacteid.Text);
    cmd.Parameters.AddWithValue("@email", txtemail.Text);
    cmd.Parameters.AddWithValue("@phonenumber", txtphonenumber.Text);
    cmd.ExecuteNonQuery();    <--------Error line
    labmsg.Text = "User " + txtcharactername.Text + " is successfully registered";
    sqlconn.Close();
