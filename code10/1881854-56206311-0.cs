    // Parametros del comando
    if (oCliente.Cli_Apellido == null)
    {
        // if this value is NULL, use "DBNull.Value" for your parameter
        cmd.Parameters.Add("@ape", SqlDbType.VarChar, 100).Value =  DBNull.Value;
    }
    else
    { 
        cmd.Parameters.Add("@ape", SqlDbType.VarChar, 100).Value =  oCliente.Cli_Apellido);
    }
