        Person p1   = new Person();
    p1.Name     = "John";
    p1.Address  = "Address1";
    p1.Age = 20;
    // Establish a connection to Oracle
    OracleConnection con = new OracleConnection(constr);
    con.Open();
    // Update Person object and insert it into a database table
    OracleCommand cmd = new OracleCommand(sql1, con);
    cmd.CommandType = CommandType.StoredProcedure;
    OracleParameter param1 = new OracleParameter();
    
    param1.OracleDbType   = OracleDbType.Object;
    param1.Direction      = ParameterDirection.InputOutput;
    // Note: The UdtTypeName is case-senstive
    param1.UdtTypeName     = "SCOTT.ODP_OBJ1_SAMPLE_PERSON_TYPE";   
    param1.Value           = p1;
    
    cmd.Parameters.Add(param1);
