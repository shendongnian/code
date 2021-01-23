        List<Student> list = new List<Student>();
        [WebMethod]
        public string InsertUserDetails(Student  userInfo)
        { 
            list.Add(userInfo);
            //string Message;
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Sample;Integrated Security=True");
            con.Open();
            foreach (Student s in list)
            {
                SqlCommand cmd = new SqlCommand("insert into userdetail(username,password,country,email) values(@UserName,@Password,@Country,@Email)", con);
                cmd.Parameters.AddWithValue("@UserName", userInfo.UserName);
                cmd.Parameters.AddWithValue("@Password", userInfo.Password);
                cmd.Parameters.AddWithValue("@Country", userInfo.Country);
                cmd.Parameters.AddWithValue("@Email", userInfo.Email);
                int result = cmd.ExecuteNonQuery();
            }
            
                //if (result == 1)
                //{
                //    Message = userInfo.UserName + " Details inserted successfully";
                //}
                //else
                //{
                //    Message = userInfo.UserName + " Details not inserted successfully";
                //}
                //con.Close();
            
               // return Message;
            return "done";
            
        }
