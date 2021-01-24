      public List<LeaveInfo> getLeaveInfo(string id, string date)
      {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConnectStr("Schedules")))
                {
                    var param = new DynamicParameters();
                    param.Add("@ID", id, DbType.String, ParameterDirection.Input);
                    param.Add("@Date_", date, DbType.String, ParameterDirection.Input);
                    return connection.Query<LeaveInfo>("dbo.LeaveCalendar_GetLeave", param, commandType: CommandType.StoredProcedure).ToList();                
    
                    //return connection.Query<Person>("dbo.Personnel_GetShift @Shift_", new { Shift_ = shift_ }).ToList();
                    //return connection.Query<Truck>("dbo.Trucks_GetTrucks").ToList();
                }
    }
