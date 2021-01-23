            SqlConnection con = new SqlConnection(Connection String for you database);
            con.Open();
            SqlCommand comm = con.CreateCommand();
            comm.CommandText = "SELECT u.UserID, u.Fname, u.Lname, u.GenderID, g.Gender 
                                FROM tblUsers u, tblGenders g 
                                WHERE u.GenderID = g.GenderID";
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
