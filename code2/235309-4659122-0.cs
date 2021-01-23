        string sql = "select department_name from departments where department_id = " +
          ":department_id";
        
    OracleCommand cmd = new OracleCommand(sql, conn);
        cmd.CommandType = CommandType.Text;
        OracleParameter p_department_id = new OracleParameter(); 
        p_department_id.OracleDbType = OracleDbType.Decimal;     
        p_department_id.Value = 20;                              
        cmd.Parameters.Add(p_department_id);                     
        
        OracleDataReader dr = cmd.ExecuteReader();
        dr.Read();
        
        departments.Items.Add(dr.GetString(0));
