    public  int Studentid()
    {
            int studentId = -1;
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(connectionStr);
                SqlCommand cmd = new SqlCommand("SELECT s_id FROM student where name = + ('" + Request.QueryString.ToString() + "')", con);
                SqlDataReader dr = null;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    studentId = dr.GetInt32(0);
                }
                dr.Close();
    
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
           return studentId;
     }
