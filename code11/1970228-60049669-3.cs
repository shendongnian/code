    public async Task<AdoNetResult> FillAlarmsDataTable() {
        string connectionString = _config.GetConnectionString("Data:DefaultConnection:ConnectionString");
        try {
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText1 = "SELECT * FROM [dbo].[Alarms] ORDER BY Name";
            // Create a new data adapter based on the specified query.
            dataAdapter = new SqlDataAdapter(cmdText1, connection);
            // Populate a new data table and bind it to the BindingSource.
            alarmDataTable = new DataTable {
                Locale = CultureInfo.InvariantCulture
            };
            await Task.Run(() => dataAdapter.Fill(alarmDataTable));
            
            // Return what ?
            return AdoNetResult.Success; 
        } catch (Exception ex) {
            // Return the task with details of the exception
            return AdoNetResult.Failed(ex);
        }
    }
