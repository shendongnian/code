    static void UpdateCheckedState(bool state) {
        string connectionstring = "<yourconnectionstring>";
        using (SqlConnection connection = new SqlConnection(connectionstring)) {
            try {
                connection.Open();
            }
            catch (System.Data.SqlClient.SqlException ex) {
                // Handle exception
            }
            string updateCommandText = "UPDATE Settings SET Value = @state WHERE Name = 'CheckboxState'";
            using (SqlCommand updateCommand = new SqlCommand(updateCommandText, connection)) {
                SqlParameter stateParameter = new SqlParameter("state", state);
                updateCommand.Parameters.Add(stateParameter);
                try {
                    updateCommand.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException ex) {
                    // Handle exception
                }
            }
        }
    }
