    private void InsertUserData(int Type, String UserName, String Password)
    {
        // The "Using" block handles object creation and disposal - 
        // handy for unmanaged resources like database connections:
        using(OleDbConnection cn = new OleDbConnection(YourConnectionString))
        {
            using(OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = cn;
                // 1.  Note the use of Parameters here. This will hinder attempts to 
                // compromise your app with SQl Injection and/or faulty user input. 
                    
                // 2. Also note that, since "Type", "Username", and "Password" are all 
                // MS Access keywords, there is a potential for problems when 
                // used as fieldnames. Therefore we enclose them 
                // in square brackets [] in the "INSERT INTO" Clause:
                String SQL =
                    "INSERT INTO PersonalData([Type], [UserName], [Password]) " +
                    "VALUES(@Type, @UserName, @Password)";
                // Set the CommandText Proprty:
                cmd.CommandText = SQL;
                // Now create some OleDb Parameters:
                OleDbParameter prmType = new OleDbParameter("@Type", Type);
                OleDbParameter prmUserName = new OleDbParameter("@UserName", UserName);
                OleDbParameter prmPassword = new OleDbParameter("@Password", Password);
                // Add the params to the parameters collection:
                cmd.Parameters.Add(prmType);
                cmd.Parameters.Add(prmUserName);
                cmd.Parameters.Add(prmPassword);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
