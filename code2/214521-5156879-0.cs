            public bool AddNewUser(string userId, string pwd, string dept,string mail,string displayName)
        {
            //get the username    
            string UserName = userId;
   
            SqlConnection conn = new SqlConnection(GetConnectionString());     //sql command to add the user and password to the database    
            SqlCommand cmd = new SqlCommand("INSERT INTO MAIN_USER_DATA(USERID, PWD,DEPARTMENT,MAIL,DISPLAY_NAME) VALUES (@USERID, @PWD,@DEPARTMENT,@MAIL,@DISPLAY_NAME)", conn);    
            cmd.CommandType = CommandType.Text;     //add parameters to our sql query    
            cmd.Parameters.AddWithValue("@USERID", UserName);   
            cmd.Parameters.AddWithValue("@PWD", GenerateHash(userId ,pwd));
            cmd.Parameters.AddWithValue("@DEPARTMENT", dept);
            cmd.Parameters.AddWithValue("@MAIL", mail);
            cmd.Parameters.AddWithValue("@DISPLAY_NAME", displayName);
            using (conn)    {        //open the connection       
                conn.Open();        //send the sql query to insert the data to our Users table 
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
           
        }
        public bool ValidateUser(string userId, string password)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString())) 
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT PWD FROM MAIN_USER_DATA WHERE USERID=@USERID";
                command.Parameters.Add("@USERID", SqlDbType.NVarChar, 25).Value = userId;
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    byte[] storedPwd = (byte[])dr["PWD"];
                    byte[] currentPwd = GenerateHash(userId, password);
                    for (int i = 0;i< storedPwd.Length; i++)
                    {
                        if (storedPwd[i] != currentPwd[i])
                        {
                            return false;
                        }
                    }
                }
                else
                    return false;
                return true;
            }
        }
        private byte[] GenerateHash(string userId, string password)
        {
            //create the MD5CryptoServiceProvider object we will use to encrypt the password    
            HMACSHA1 hasher = new HMACSHA1(Encoding.UTF8.GetBytes(userId));             //create an array of bytes we will use to store the encrypted password    
            //Byte[] hashedBytes;    //Create a UTF8Encoding object we will use to convert our password string to a byte array    
            UTF8Encoding encoder = new UTF8Encoding();     //encrypt the password and store it in the hashedBytes byte array    
            return hasher.ComputeHash(encoder.GetBytes(password));     //connect to our db 
        }
