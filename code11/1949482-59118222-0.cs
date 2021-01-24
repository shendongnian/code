    SqlDataReader userReader = userQueryExecuteReader();
    if (userReader.Read())
    {
         NewUser.Username = userReader[0].ToString();
         NewUser.Password = userReader[1].ToString();
    }
