    protected void DropDownList1_SelectedIndexChanged(object sender, 
        EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Ceng.mdf;Integrated Security=True");
    
            int selectedCourseId = 0;
            string qs = Request.QueryString["id"];        
    
            int.TryParse(qs, out selectedCourseId);
    
            string sv = DropDownList1.SelectedItem.Value;           
        
            SqlCommand cmd = new SqlCommand("Select * from Enrolment as e, Students as s where e.StudentID = s.StudentID and " +
                              "e.CourseID = @CourseID and s.StudentName = @StudentName", con);
            
            cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = selectedCourseId;
            cmd.Parameters.Add("@StudentName", SqlDbType.NVarChar).Value = sv;
            
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
    
            if(reader.HasRows)
            {
                Label1.Visible = true;
                Label1.Text = "The selected student is already registered to the course!";
                Label1.ForeColor = Color.Red;
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "The selected student is succesfully registered!";
                Label1.ForeColor = Color.Green;
    
    
                SqlDataSource4.Insert();
                GridView1.DataBind();
            }
    
            reader.Close();
            con.Close();
        }
