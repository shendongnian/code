    System.Data.SqlClient.SqlDataReader rdr = null;
            System.Data.SqlClient.SqlConnection conn = null;
            System.Data.SqlClient.SqlCommand selcmd = null;
            try
            {
                conn = new System.Data.SqlClient.SqlConnection
              (System.Configuration.ConfigurationManager.ConnectionStrings
              ["ConnectionString"].ConnectionString);
                selcmd = new System.Data.SqlClient.SqlCommand
              ("select pic1 from msg where msgid=" +
              Request.QueryString["imgid"], conn);
                conn.Open();
                rdr = selcmd.ExecuteReader();
                while (rdr.Read())
                {
                   Response.ContentType = "image/jpg";
                   Response.BinaryWrite((byte[])rdr["pic1"]);
                }
                if (rdr != null)
                    rdr.Close();
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
