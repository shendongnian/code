    string sqlStatement = "INSERT INTO tenant(username, password, firstname, 
    lastname, email, current_address, phone, appartmentType) values(@username, 
    @password, @firstName, @lastName, @email, @address, @phone,     
    @appartmentType)";
   
    SQLiteCommand command = new SQLiteCommand(con)
    command.Text = sqlStatement;
    command.CommandType = SQLiteCommandType
    command.CommandType = CommandType.Text;
    command.Parameters.Add(new SQLiteParameter("@username", username));
    command.Parameters.Add(new SQLiteParameter("@password", password));
    command.Parameters.Add(new SQLiteParameter("@firstname", firstname));
    command.Parameters.Add(new SQLiteParameter("@lastname", lastname));
    command.Parameters.Add(new SQLiteParameter("@email", email));
    command.Parameters.Add(new SQLiteParameter("@current_address", current_address));
    command.Parameters.Add(new SQLiteParameter("@phone", phone));
    command.Parameters.Add(new SQLiteParameter("@appartmentType", appartmentType));
                
    command.ExecuteNoneQuery();
