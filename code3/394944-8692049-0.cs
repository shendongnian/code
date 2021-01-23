        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("rate", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@course_ID", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@postID", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@myemail", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@rate", System.Data.SqlDbType.VarChar);
                    conn.Open();
                    foreach (DataListItem item in DataList2.Items)
                    {
                        RadioButtonList RadioButtonList1 = (RadioButtonList)DataList2.FindControl("RadioButtonList1");
                        if (RadioButtonList1.SelectedItem != null)
                        {
                            string choice = RadioButtonList1.SelectedItem.Value;
                            Label post_IDLabel = (Label)item.FindControl("post_IDLabel");
                            cmd.Parameters["@course_ID"].Value = Convert.ToInt32(Request.QueryString["courseID"]);
                            cmd.Parameters["@postID"].Value = Convert.ToInt32(post_IDLabel.Text);
                            cmd.Parameters["@myemail"].Value = Session["email"] as string;
                            cmd.Parameters["@rate"].Value = Convert.ToInt32(RadioButtonList1.SelectedItem.Value);
                            cmd.ExecuteNonQuery();
                            Response.Write(choice);
                        }
                    }
                }
            }
            DataList2.DataBind();
        }
