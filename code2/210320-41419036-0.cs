        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Courses = new List<string>();
            SqlConnection con = new SqlConnection("the connection string here");
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT courseName, courseDescription FROM db.Courses WHERE CourseName LIKE %@CourseName%";
            cmd.Parameters.AddWithValue("@CourseName", textBox1.Text);
            con.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string course = reader["CourseName"].ToString();
                course += ", " + reader["CourseDescription"].ToString();
                Courses.Add(course);
            }
            reader.Close();
            foreach (string course in Courses)
            {
                //wherever and however you would like to display
            }
        }
