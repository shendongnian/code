    if (e.CommandName == "AddToCart") {
     Session["uid"] = 1;
     Label lbl = (Label) e.Item.FindControl("PIDLabel");
     lblAtC.Text = lbl.Text;
     ShowMessage("Product successfully added to Cart", MessageType.Success);
    
     string connStr = ConfigurationManager.ConnectionStrings["MWM1812ConnString"].ConnectionString;
     SqlConnection conn = new SqlConnection(connStr);
    
     conn.Open();
    
     string sqlQuery = "SELECT * FROM tblShoppingCart WHERE uid=@uid AND pid=@pid";
     SqlCommand comm = new SqlCommand(sqlQuery, conn);
     comm.Parameters.AddWithValue("@uid", Session["uid"]);
     comm.Parameters.AddWithValue("@pid", lblAtC.Text.Trim());
     using(SqlDataReader reader = comm.ExecuteReader()) {
      if (!reader.HasRows()) {
       string sqlQuery2 = "UPDATE tblShoppingCart SET qty=qty+1 WHERE uid=@uid AND pid=@pid";
    
       // Add code for adding parameters and executing sqlQuery2 
      } else {
       while (reader.Read()) {
    
    
        string sqlQuery1 = "INSERT INTO tblShoppingCart (uid, pid, qty, dtShopped) VALUES (@uid, @pid, @qty, @dtShopped)";
        SqlCommand comma = new SqlCommand(sqlQuery, conn);
        comm.Parameters.AddWithValue("@uid", Session["uid"]);
        comm.Parameters.AddWithValue("@pid", lblAtC.Text);
        comm.Parameters.AddWithValue("@qty", 1);
        //comm.Parameters.AddWithValue("@dtShopped", DateTime.Now.ToLongDateString());
        comm.Parameters.AddWithValue("@dtShopped", DateTime.Now.ToString());
    
        int result = comm.ExecuteNonQuery();
    
       }
      }
     }
    }
    
