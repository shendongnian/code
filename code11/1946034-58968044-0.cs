     static void Main(string[] args)
            {
                string connectionstring = @"";
                SqlConnection connection = new SqlConnection(connectionstring);
                string filePath = @"C:\Users\me\folder1\foo\bar\documents\photos\img1.jpg";
                var list = ReturnList(connection,filePath);
    
    
            }
            static List<string> ReturnList(SqlConnection connection,string path)
            {
                List<string> list = new List<string>();
                char[] t = { '\\'};
                var array=path.Split(t).ToList();
                connection.Open();
                string sql = "select * from Record";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string a = reader["Name"].ToString();
                    if(array.Contains(a))
                    {
                        list.Add(a);
                    }
                }
                connection.Close();
                return list;
            }
