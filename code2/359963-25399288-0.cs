    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Data;
    using System.Data.Entity;
    using System.Net;
    using System.Data.SqlClient;
    public partial class StudentRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Marks { get; set; }
        public string Grade { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
    }
    public class SqlMyModelRespoitory : First_Test_DBEntities 
    {
        public StudentRecord GetSingleModel()
        {
            StudentRecord model;
            string connString = @"Paste Your Local Connection String";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertStudent";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new StudentRecord
                            {
                                Id = Convert.ToInt32(reader[0]),
                                Name = reader[1].ToString(),
                                Marks = reader[1].ToString(),
                                Grade = reader[1].ToString(),
                                DOB = Convert.ToDateTime(reader[1])
                            };
                        }
                    }
                }
            }
            return model;
        }
    }
}
