       using System;
       using System.Data.SqlClient;
        // more here likely...
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        	string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Ceng.mdf;Integrated Security=True";
        	string getStudentIdSql = @"
        		SELECT s.StudentID 
        	 	FROM Enrolment AS e
        		INNER JOIN Students AS s 
        			ON e.StudentID = s.StudentID 
        			AND E.CourseID = @CourseID
        			AND StudentName = @StudentName
        	";
        	int courseId = int.Parse(Request.QueryString["id"]); // consider tryparse here, I make assumptions on the int also
        	// string studentName = DropDownList1.SelectedItem.Value; // assumption if the values are there
        	string studentName = DropDownList1.SelectedItem.Text; // assumption based on code/comments, key part where it is defined is missing from question
        	using (SqlConnection conn = new SqlConnection(connectionString))
        	{
        		using (SqlCommand cmd = new SqlCommand(getStudentIdSql, conn))
        		{
        			cmd.Parameters.Add("@CourseID", SqlDbType.Int).Value = courseId;
        			cmd.Parameters.Add("@StudentName", SqlDbType.VarChar, 80).Value = studentName;
        			SqlDataReader reader = cmd.ExecuteReader();
        			if (reader.HasRows)
        			{
        				/* if we wanted to have the rows
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)}\t{ reader.GetString(1)}");
                    }
                    */
        				Label1.Visible = true;
        				Label1.Text = "The selected student is already registered to the course!";
        				Label1.ForeColor = Color.Red;
        			}
        			/* basic thing
                else
                {
                    Console.WriteLine("No rows found.");
                }
                */
        			else
        			{
        				Label1.Visible = true;
        				Label1.Text = "The selected student is succesfully registered!";
        				Label1.ForeColor = Color.Green;
        				SqlDataSource4.Insert();
        				GridView1.DataBind();
        			}
        
        			reader.Close();
        		}
        	}
        }
