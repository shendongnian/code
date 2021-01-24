        private readonly SqlConnection _con = new SqlConnection("Data Source=.;Initial 
        Catalog=dbPhoneBook;Integrated Security=True");
 
    public string Add(string user , string pass)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = _con;
                cmd.CommandText = "insert into tbl_login(user,pass)values(@user,@pass)";
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                if (_con.State != ConnectionState.Open)
                {
                    _con.Open();
                }
                cmd.ExecuteNonQuery();
                result = "Ok";
                cmd.Dispose();
            }
            catch
            {
                cmd.Dispose();
                result = "NOk";
            }
            return result;
        }
