    // TODO set up your connection string
        private string connectionString = "<your connection string>";
        // Gets data assyncronously
        public static async Task<DataTable> GetDataAsync(string procedureName, object[,] ParamArray)
        {
            try
            {
                var asyncConnectionString = new SqlConnectionStringBuilder(connectionString)
                {
                    AsynchronousProcessing = true
                }.ToString();
                using (var conn = new SqlConnection(asyncConnectionString))
                {
                    using (var SqlCommand = new SqlCommand())
                    {
                        SqlCommand.Connection = conn;
                        SqlCommand.CommandText = procedureName;
                        SqlCommand.CommandType = CommandType.StoredProcedure;
                        string ParamName;
                        object ParamValue;
                        for (int i = 0; i < ParamArray.Length / 2; i++)
                        {
                            ParamName = ParamArray[i, 0].ToString();
                            ParamValue = ParamArray[i, 1];
                            SqlCommand.Parameters.AddWithValue(ParamName, ParamValue);
                        }
                        conn.Open();
                        var data = new DataTable();
                        data.BeginLoadData();
                        using (var reader = await SqlCommand.ExecuteReaderAsync().ConfigureAwait(true))
                        {
                            if (reader.HasRows)
                                data.Load(reader);
                        }
                        data.EndLoadData();
                        return data;
                    }
                }
            }
            catch (Exception Ex)
            {
                // Log error or something else
                throw;
            }
        }
        public static async Task<DataTable> GetData(object General, object Type, string FromDate, string ToDate)
        {
            object[,] parArray = new object[,]{
            {"@BranchID",General.BranchID},
            {"@FinancialYearID",General.FinancialYearID},
            {"@Type",Type},
            {"@FromDate",DateTime.ParseExact(FromDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)},
            {"@ToDate",DateTime.ParseExact(ToDate, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture)}
            };
            return await DataBaseHelper.GetDataAsync("SelectOutstandingReportDetailed", parArray);
        }
        // Calls database assyncronously
        private async Task ConsumeData()
        {
            DataTable dt = null;
            try
            {
                // TODO configure your parameters here
                object general = null;
                object type = null;
                string fromDate = "";
                string toDate = "";
                dt = await GetData(general, type, fromDate, toDate);
            }
            catch (Exception Ex)
            {
                // do something if an error occurs
                System.Diagnostics.Debug.WriteLine("Error occurred: " + Ex.ToString());
                return;
            }
            foreach (DataRow dr in dt.Rows)
            {
                System.Diagnostics.Debug.WriteLine(dr.ToString());
            }
        }
        // Fired when some button is clicked. Get and use the data assyncronously, i.e. without blocking the UI.
        private async void button1_Click(object sender, EventArgs e)
        {
            await ConsumeData();
        }
