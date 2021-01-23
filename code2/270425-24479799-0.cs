    SqlConnection con = new SqlConnection(conString);
    con.close();
    cmd=new SqlCommand("DELETE FROM compsTickers", con);
    con.Open();
    int i = cmd.ExecuteNonQuery();
    if(i>0)
    {
     MessageBox.Show("Successful.");
    }
    con.Close();
