    OracleParameter op = null;
    OracleDataReader dr = null;
    /* custom code here. Yours would look a little different */
    OracleCommand cmd = (OracleCommand) this.FactoryCache.Connection.CreateCommand();
    cmd.CommandText = "pkg_prov_index.getNextPanel";
    cmd.CommandType = CommandType.StoredProcedure;
    op = new OracleParameter("pCurrentPanelId", OracleType.VarChar);
    op.Direction = ParameterDirection.Input;
    op.Value = masterProviderIndex.CurrentPanelId;
    cmd.Parameters.Add(op);
    op = new OracleParameter("pRefCursor", OracleType.Cursor);
    op.Direction = ParameterDirection.Output;
    cmd.Parameters.Add(op);
    op = new OracleParameter("pReturnCode", OracleType.Number);
    op.Direction = ParameterDirection.Output;
    op.Size = 5;
    cmd.Parameters.Add(op);
    op = new OracleParameter("pReturnMessage", OracleType.VarChar);
    op.Direction = ParameterDirection.Output;
    op.Size = 4000;
    cmd.Parameters.Add(op);
    cmd.ExecuteNonQuery();
    returnCode = Convert.ToInt16(cmd.Parameters[2].Value);
    returnMessage = cmd.Parameters[3].Value.ToString();
    dr = (OracleDataReader) cmd.Parameters[1].Value;
    while (dr.Read()) {
    }
