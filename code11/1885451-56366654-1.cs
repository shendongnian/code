    public static MySqlCommand CreateParameterizedQuery(string sql, List<MySqlParameter> parameters, MySqlConnection connection)
        {
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            foreach (MySqlParameter parameter in parameters) cmd.Parameters.Add(parameter);
            return cmd;
        }
        public static List<MySqlParameter> CreateParametersFor(Coordinate coordinate)
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            MySqlParameter latitude = new MySqlParameter()
            {
                ParameterName = "@Latitude",
                Value = coordinate.Latitude
            };
            MySqlParameter longitude = new MySqlParameter()
            {
                ParameterName = "@Longitude",
                Value = coordinate.Longitude
            };
            MySqlParameter measurementId = new MySqlParameter()
            {
                ParameterName = "@MeasurementId",
                Value = coordinate.MeasurementId
            };
            parameters.Add(latitude);
            parameters.Add(longitude);
            parameters.Add(measurementId);
            return parameters;
        }
