          command.CommandText = "INSERT INTO Login([Username],[Password]) VALUES(@Username, @Password)";
          
          //Not sure how you create your commands in your project
          //here I'm using the ProviderFactory to create instances of provider specific DbCommands.
          
          var parameter = dbProviderFactory.CreateParameter();
          parameter.DbType = System.Data.DbType.String;
          parameter.ParameterName = "@Username";
          parameter.Value = AddUsernameTextBox.Text;
          command.Parameters.Add(parameter);
          parameter = dbProviderFactory.CreateParameter();
          parameter.DbType = System.Data.DbType.String;
          parameter.ParameterName = "@Password";
          parameter.Value = AddPasswordTextBox.Text;
          command.Parameters.Add(parameter);
