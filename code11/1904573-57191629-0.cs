    private void SaveGlobalOrderDays(IEnumerable<SessionInfoList> sessionList, IEnumerable<Holiday> selectedOrderHolidays, IEnumerable<Holiday> selectedHolidays, IEnumerable<string> orderDays, IEnumerable<string> noOrderDays)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("[dbo].[SaveGlobalOrderDays]", connection))
            {
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SessionId", SqlDbType.Int);
                //Add a Length to these!
                cmd.Parameters.Add("@HolidayName", SqlDbType.NVarChar); 
                cmd.Parameters.Add("@SelectedHolidayName", SqlDbType.NVarChar);
                cmd.Parameters.Add("@OrderDays", SqlDbType.NVarChar);
                cmd.Parameters.Add("@NoOrderDays", SqlDbType.NVarChar);
                connetion.Open();
                foreach (SessionInfoList session in sessionList)
                {
                    cmd.Parameters["@SessionId"].Value = session.SessionID;
                    cmd.Paramters["@HolidayName"].Value = DBNull.Value;
                    string joinedNames = string.Join(",", selectedOrderHolidays.Select(h => h.Name.Trim()));
                    if (!string.IsNullOrEmpty(joinedNames))
                        cmd.Paramters["@HolidayName"].Value = joinedNames;
                    cmd.Paramters["@SelectedHolidayName"].Value = DBNull.Value;
                    joinedNames = string.Join(",", selectedHolidays.Select(h => h.Name.Trim()));
                    if (!string.IsNullOrEmpty(orderHolidays))
                        cmd.Paramters["@SelectedHolidayName"].Value = joinedNames;
                    cmd.Paramters["@OrderDays"].Value = DBNull.Value;
                    joinedNames = string.Join(",", orderDays);
                    if (!string.IsNullOrEmpty(joinedNames))
                        cmd.Paramters["@OrderDays"].Value = joinedNames;
                    cmd.Paramters["@NoOrderDays"].Value = DBNull.Value;
                    joinedNames = string.Join(",", noOrderDays);
                    if (!string.IsNullOrEmpty(joinedNames))
                        cmd.Paramters["@NoOrderDays"].Value = joinedNames;
 
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string message = "Failed to save global order info";
                // Logger.Error(LogSource, "SaveGlobalOrderDays", string.Empty, message, string.Empty, ex);
                throw new Exception(message, ex);
            }
        }
