    private List<T> GetData<T>(DateTime? startDate, DateTime? endDate, bool IsSelectAll)
            {
                List<T> ret = new List<T>();
                string tableName = "";//Select the table name based on T here
                string sql = "";
    
                if (IsSelectAll)
                {
                    sql = "select * from tbl_sensor_data";
                }
                else
                {
                    sql = "select * from tbl_sensor_data where Timestamp between @start_date and @end_Date";
                }
                //Build your list using the appropriate converter based on T here        
                return Converter.SerializeToSensorDataList(this.GetData(startDate, endDate, IsSelectAll, sql)); 
            }
