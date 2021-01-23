    using (var connection = New SqlConnection(connString))
        using (var command = connection.CreateCommand()) {
            command.CommandText = "select BasketId from tblBasket where UserId = N'9f96bd94-91b9-4328-8214-4eac179c3a26'";
            command.CommandType = CommandType.Text;
            
            try {
                var basketId = (string)command.ExecuteScalar(); // Assuming BasketId is a string, since you called ToString() in your question.
            } finally {
                command.Dispose();
                connection.Dispose();
            }
        }
