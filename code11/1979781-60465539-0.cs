    using (var sqlConnection = new SqlConnection(_configuration["DefaultConnection"]))
        {
            sqlConnection.Open();
    
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "SELECT Schedules.AppointmentHeading, Schedules.AppointmentDateStart, Schedules.AppointmentDateEnd, Bookers.Email as BookingEmail, Rooms.Id AS Expr3, Rooms.Name as RoomName" +
                                      "FROM Schedules " +
                                      "INNER JOIN Rooms ON Schedules.RoomId = Rooms.Id " +
                                      "INNER JOIN Bookers ON Schedules.BookerId = Bookers.Id";
    
                command.CommandType = CommandType.Text;
    
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                              result.AppointmentHeading = Convert.ToString(reader["AppointmentHeading"]);
                              result.AppointmentStart = Convert.ToDateTime(reader["AppointmentDateStart"]);
                              result.AppointmentEnd = Convert.ToDateTime(reader["AppointmentDateEnd"]);
                              result.BookingEmail = COnvert.ToString(reader["BookingEmail"]);
                              result.RoomName = Convert.ToString(reader["RoomName"]);
                        
                        }
                    }
                }
            }
        }
