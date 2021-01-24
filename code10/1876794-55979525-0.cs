c#
MySqlCommand cmd = new MySqlCommand("select count(CNIC) from reportcrime where CNIC='"+Convert.ToString(txtCnicNo.Text)+"'", con);
use this method if u just want to check CNIC and if u want to insert new data your insertion method will goes on else block
c#
public bool checkCNIC(string CNIC)
{
    bool flag = false;
    using (SqlConnection con = new SqlConnection(Config.ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("select COUNT(CNIC) from reportcrime where CNIC='"+Convert.ToString(txtCnicNo.Text)+"'", con))
        {
            con.Open();
            string count = (string) cmd.ExecuteScalar();
            if(count > 0)
            {
                flag = true;
console.writeLine("user exists")
            }
else
{
console.writeLine("new user")
}
        }
    }
    return flag;
}
