        string sqlString = "select * from hsinfo WHERE rname=@st";
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseName"].ConnectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                cmd.Parameters.Add("@st", st);
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        this.Label1.Text = rd["rmail"].ToString();
                    }
                }
            }
        }
