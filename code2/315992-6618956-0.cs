    public static class StudentRegister
    {
        private static Random s = new Random();
        static string[] student = new string[] { "wei ting", "jin ling", "wei wei", "shi ya", "yi ting", "an qin", "lian en" };
        public static string GetStudent()
        {
            return student[s.Next(0, student.Count())];
        }
    }
    private void btnStudentAdd_Click(object sender, EventArgs e)
    {
        using (var conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True"))
        {
            conn.Open();
            using (var cmd = new SqlCommand("INSERT INTO StudentList (StudentName) VALUES (@Name)", conn))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                for (int i = 0; i < 3; i++)
                {
                    cmd.Parameters["@Name"].Value = StudentRegister.GetStudent();
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
        GridviewBind();  //bind the create data back to datagridview
    }
