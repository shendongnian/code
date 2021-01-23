    mySqlCommand.CommandText = "app_customers";
    mySqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
    mySqlCommand.Parameters.AddWithValue("@name", theValue);
    var customerIdParam = mySqlCommand.Parameters.Add("@customer_id", System.Data.SqlDbType.Int);
    customerIdParam.Direction = System.Data.ParameterDirection.Output;
    // add more parameters, setting direction as appropriate
    mySqlCommand.ExecuteNonQuery();
    int customerId = (int)customerIdParam.Value;
    // read additional outputs
