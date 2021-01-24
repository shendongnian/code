    var item = oracleDataReader.GetOracleValue(columnIndex);
    if (item is OracleClob clob)
    {
        if (clob != null)
        {
            // use clob.Value ...
            clob.Close();
        }
    }
