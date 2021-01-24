using (var db = new MySqlConnection(ConfigurationHandler.GetSection<string>(StringConstants.ConnectionString)))
                {
                    resultSet = db.Execute(UpdateQuery,
                        new { _val = terminalId }, commandType: CommandType.Text);
                }
