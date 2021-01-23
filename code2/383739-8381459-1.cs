    protected void Button1_Clicked(object sender, EventArgs e)
    {
            //If one of the items is selected AND a username exists in the Username session object update the user role
            if (!String.IsNullOrEmpty(radio1.SelectedValue) && Session["Username"] != null)
            {
                string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspdb;Integrated Security=True";
                string deleteCommand = "DELETE FROM UserRole where Username=@Username";
                string cmdText = "INSERT INTO UserRole (RoleName,Username) values(@RoleName,@Username)";
                    
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    //first the delete command
                    using (SqlCommand cmd = new SqlCommand(deleteCommand, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username",Session["Username"].ToString());
                        cmd.ExecuteNonQuery();
                        //Now the insert
                        cmd.CommandText=cmdText;
                        cmd.Parameters.Clear(); //need this because still has params from del comm
                        cmd.Parameters.AddWithValue("@RoleName",radio1.SelectedValue);
                        cmd.Parameters.AddWithValue("@Username",Session["Username"].ToString());
                        cmd.ExecuteNonQuery();
                        infoSpan.InnerText = String.Format("The users role has been updated to - {0}", radio1.SelectedValue);
                    }
                }
            }
    }
