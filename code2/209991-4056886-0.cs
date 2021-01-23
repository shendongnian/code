            // Define a parameter object.
            var numParam = new SqlParameter();
            numParam.ParameterName = " @num";
            numParam.SqlDbType = SqlDbType.Int;
            numParam.Value = num; // << This is where your value goes. 
            // Provide the parameter to the command to use. 
            cmd.Parameters.Add( numParam );
