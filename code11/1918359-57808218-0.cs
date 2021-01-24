        using( var connect = new MySqlConnection("Server=localhost;Database=Work;Uid=root;Pwd='1234';"))
        using( var query = new MySqlCommand(@"UPDATE user SET User_Name=@User_Name,User_BankBalance=@User_BankBalance,User_Password=@User_Password,LottoTimer=@LottoTimer WHERE User_Name='" + Escape(u.Username) + "'", connect))
        {
            connect.Open();
            query.CommandType = System.Data.CommandType.Text;
            query.Parameters.AddWithValue("@User_Name", Escape(u.Username));
            query.Parameters.AddWithValue("@User_BankBalance", u.BankBalance);
            query.Parameters.AddWithValue("@User_Password", u.Password);
            query.Parameters.AddWithValue("@LottoTimer", u.LottoTimer);
            query.Prepare();
            query.ExecuteNonQuery();
        }
        return;
It is important to dispose the MySqlConnection, so it can be available to the pool again. The problem you have is that all connections are used in the pool, and it is waiting for one - until the timeout.
