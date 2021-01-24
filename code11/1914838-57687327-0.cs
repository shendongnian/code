     SOLVED! Just a matter of getting the Code Rejigged.
     Code Now Reads:
            string conn = 
            ConfigurationManager.ConnectionStrings["SVCCAssetsDb"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(conn);
            sqlcon.Open();
            int txttype = Convert.ToInt32(lblType.Text);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                //move lbl inside loop
                int uniquenuumber = Convert.ToInt32(txtUN.Text);
                
                HttpPostedFile postedFile = Request.Files[i];
                if (postedFile.ContentLength > 0)
                {
                    //lblType.Text = txtType.Text;
                    //int txttype = 1;
                    txttype = Convert.ToInt32(lblType.Text);
                    string userid = lblid.Text;
                    string fileName = Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(Server.MapPath("~/Attachment/") + fileName);
                    lblMessage.Text += string.Format("<b>{0}</b> uploaded.<br />", 
        fileName);
                    string sqlquery = "INSERT INTO Attachment (UserName, FilePath, 
        UniqueNumber, TypeCode) VALUES ('" + userid + "', + '" + fileName + "', + '" + 
       uniquenuumber + "', '" + txttype + "')";
                    SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                }
            }
            sqlcon.Close();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = ((DropDownList)sender).SelectedValue;
            if (!string.IsNullOrEmpty(txtType.Text))
            txtType.Text = selectedValue;
            lblType.Text = selectedValue;
        }
