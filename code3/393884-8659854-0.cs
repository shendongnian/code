    foreach (DataListItem item in DataList2.Items)
    {
        TextBox TextBox1 = (TextBox)item.FindControl("TextBox1");
        string text = TextBox1.Text;
        if (!string.IsNullOrEmpty(text)) {
          Label post_IDLabel = (Label)item.FindControl("post_IDLabel");
          string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
          SqlConnection conn = new SqlConnection(connStr);
          SqlCommand cmd = new SqlCommand("comment", conn);
          cmd.CommandType = CommandType.StoredProcedure;
          int post_ID = Convert.ToInt32(post_IDLabel.Text);
          string comment = text;
          string email = Session["email"].ToString();
          int course_ID = Convert.ToInt32(Request.QueryString["courseID"]);
          cmd.Parameters.Add(new SqlParameter("@course_ID", course_ID));
          cmd.Parameters.Add(new SqlParameter("@comment", comment));
          cmd.Parameters.Add(new SqlParameter("@myemail", email));
          cmd.Parameters.Add(new SqlParameter("@postID", post_ID));
          conn.Open();
          cmd.ExecuteNonQuery();
          conn.Close();
       }
    }
