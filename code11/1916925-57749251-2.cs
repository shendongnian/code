private string GetUserPassword(string userName){
	using (SqlConnection connection = db.initializare()) {
		string sqlQuery = "SELECT password FROM users WHERE username = @UserName";
        using (SqlCommand cmd = new SqlCommand(sqlQuery, connection)) {
             connection.Open();
 		     cmd.CommandType = CommandType.Text;
		     cmd.Parameters.AddWithValue("@UserName", userName);
			
		     var result = cmd.ExecuteScalar();
		     return (result == DBNull.Value) ? string.Empty : result;
        }
 	}
}
private void UpdateLogin(string userName, int isLogged){
	using (SqlConnection connection = db.initializare()) {
		string sqlQuery = "UPDATE users SET isLogged = @isLogged WHERE username = @username";
        using (SqlCommand cmd = new SqlCommand(sqlQuery, connection)) {
            connection.Open();
 			cmd.CommandType = CommandType.Text;
			cmd.Parameters.AddWithValue("@UserName", userName);
			cmd.Parameters.AddWithValue("@isLogged", isLogged);
			cmd.ExecuteNonQuery();
        }
 	}
}
public bool UserLogin(string userName, string password)
{
	string userPassword = GetUserPassword(userName);
	if (password.Equals(userPassword)){
		UpdateLogin(userName,1);
		return true;
	}
	else{
		//username or password is incorrect
	}  
	return false;
}
