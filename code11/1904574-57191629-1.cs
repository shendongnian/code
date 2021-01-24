    private void SaveGlobalOrderDays(IEnumerable<SessionInfoList> sessionList, IEnumerable<Holiday> selectedOrderHolidays, IEnumerable<Holiday> selectedHolidays, IEnumerable<string> orderDays, IEnumerable<string> noOrderDays)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("[dbo].[SaveGlobalOrderDays]", connection))
            {
                cmd.CommandTimeout = 600;
                cmd.CommandType = CommandType.StoredProcedure;
                //Set up parameter placeholders once, before any looping starts.
                // From here on out we'll only ever set their .Value properties.
                cmd.Parameters.Add("@SessionId", SqlDbType.Int);
                //Add a Length to these!
                // If the target columns really are nvarchar(max), use -1
                cmd.Parameters.Add("@HolidayName", SqlDbType.NVarChar, -1); 
                cmd.Parameters.Add("@SelectedHolidayName", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add("@OrderDays", SqlDbType.NVarChar, -1);
                cmd.Parameters.Add("@NoOrderDays", SqlDbType.NVarChar, -1);
                //Open the connection just once, immediately before beginning of the loop.
                // The using block will ensure it is closed later.
                connection.Open(); 
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
 
                    //Now there's no need to Open() or Dispose() anything at this point.
                    cmd.ExecuteNonQuery();
                }
            }
            // Consider using a separate Try/Catch inside the loop.
            // ... unless you want one failure to abort everything part way through, with some updates completed and some not.
            catch (Exception ex)
            {
                string message = "Failed to save global order info";
                // Logger.Error(LogSource, "SaveGlobalOrderDays", string.Empty, message, string.Empty, ex);
                throw new Exception(message, ex);
            }
        }
