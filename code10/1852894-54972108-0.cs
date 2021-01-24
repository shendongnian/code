    class ReadStudents
    {
        public string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;";
        public List<dynamic> GetAllStudents()
        {
            dynamic student_rec = new ExpandoObject();
            List<dynamic> rtn_list = new List<dynamic>();
            using (SqlConnection sql_con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sql_cmd = new SqlCommand())
                {
                    sql_con.Open();
                    sql_cmd.Connection = sql_con;
                    sql_cmd.CommandText = "Select ID, Name, Address from Student";
                    SqlDataReader sql_rdr = sql_cmd.ExecuteReader();
                    while ( sql_rdr.Read() )
                    {
                        student_rec.Id = sql_rdr[0].ToString();
                        student_rec.Name = sql_rdr[1].ToString();
                        student_rec.Address = sql_rdr[2].ToString();
                        rtn_list.Add(student_rec);
                    }
                }
            }
            return rtn_list;
        }
    }
