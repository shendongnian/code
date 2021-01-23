            strQuery = string.Format("EXECUTE PROCEDURE Cronos_UpdateStateLegacyProduct ({0})", oValidityProducts.PurchaseId);
            OdbcConnection oConnection = new OdbcConnection(this.strConnectionString);
            OdbcCommand oCommand = new OdbcCommand();
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.CommandText = strQuery;
            oCommand.Connection = oConnection;
            oConnection.Open();
            intResult = oCommand.ExecuteNonQuery();
