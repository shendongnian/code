       command.Parameters.Add("@product", SqlDbType.NVarChar);
       command.Parameters.Add("@component", SqlDbType.NVarChar).Value = component;
       command.Parameters.Add("@sn", SqlDbType.NVarChar).Value = sn;
       command.Parameters.Add("@date", SqlDbType.Date).Value = today;       
       foreach (string component in component_list)
       {
           command.Parameters["@component"].Value = component;
           command.ExecuteNonQuery();
       }
