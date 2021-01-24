    var parameters = new Dictionary<string, object>();
    parameters["Field1"] = "Value1";
    parameters["Field2"] = null;
    parameters["Field3"] = 5;
		
    StringBuilder builder = new StringBuilder("SELECT * FROM TABLE WHERE AlwaysUsedCondition=1 ");
        
    SqlCommand cmd = new SqlCommand();
    foreach (var parameter in parameters)
    {
        if (!string.IsNullOrWhiteSpace(parameter.Value?.ToString()))
        {
            builder.Append(" AND " + parameter.Key + "=@" + parameter.Key);
            cmd.Parameters.Add("@" + parameter.Key, parameter.Value);
        }
    }
    cmd.CommandText = builder.ToString();
