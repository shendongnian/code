    protected void delete(object sender, CommandEventArgs e) 
        {
            if ((e.CommandName == "delete") && (e.CommandArgument != null))
            {
                    string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    SqlCommand cmd = new SqlCommand("delete_post", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int post_ID = (int) e.CommandArgument;
                    string email = Session["email"].ToString();
                    int course_ID = Convert.ToInt32(Request.QueryString["courseID"]);
                    cmd.Parameters.Add(new SqlParameter("@course_ID", course_ID));
                    cmd.Parameters.Add(new SqlParameter("@myemail", email));
                    cmd.Parameters.Add(new SqlParameter("@post_ID", post_ID));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    DataList2.DataBind();
               
            }
