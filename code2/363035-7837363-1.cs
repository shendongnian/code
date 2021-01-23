    var myCommand = new SqlCommand();
    myCommand.Parameters.Add("@usernames", SqlDbType.Xml);
    string usernames = "<Usernames>"
    foreach (string username in usernames){
       usernames+= String.Format("<username>{0}</username>", username);
    }
    usernames += "</Usernames>"
    myCommand.Parameters["@usernames"].Value = usernames;
    return _dbConnection.ExecuteQuery("Select * from customer where username in (SELECT
        username.value('.', 'nvarchar') AS Username
        FROM @x.nodes('/Usernames/Username') as Usernames(Username))");
