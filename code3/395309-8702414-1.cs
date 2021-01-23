    public  int Studentid()
    {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand("SELECT s_id FROM student where name = + ('" + Request.QueryString.ToString() + "')", con);
                con.Open();
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr.GetInt32(0);
                }
    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(con != null)
                     con.Close();
                con = null;
            }
     }
