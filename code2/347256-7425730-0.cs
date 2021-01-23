    mySqlCommand.CommandText = "app_customers";
    mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
    mySqlCommand.Parameters.AddWithValue("@name", theValue);
    var outputParam = mySqlCommand.Parameters.Add("@customer_id", System.Data.SqlDbType.Int);
    outputParam.Direction = System.Data.ParameterDirection.Output;
    mySqlCommand.ExecuteNonQuery();
    int output = (int)outputParam.Value;
