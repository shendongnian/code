        protected void CreateComponentODPOnly(Oracle.DataAccess.Client.OracleConnection cntn, string tableName)
        {
            int newId;
            System.Data.DataSet _dataSet = new DataSet();
            Oracle.DataAccess.Client.OracleCommand selectCmd = new Oracle.DataAccess.Client.OracleCommand();
            selectCmd.Connection = cntn;
            selectCmd.CommandText = string.Format(
                    "SELECT * FROM {0} WHERE ID = (SELECT MAX(ID) FROM {0})", tableName);
            Oracle.DataAccess.Client.OracleDataAdapter dataAdapter = new Oracle.DataAccess.Client.OracleDataAdapter();
            Oracle.DataAccess.Client.OracleCommandBuilder cmdBuilder = new Oracle.DataAccess.Client.OracleCommandBuilder();
            dataAdapter.SelectCommand = selectCmd;
            cmdBuilder.DataAdapter = dataAdapter;
            dataAdapter.Fill(_dataSet, tableName);
            newId = Convert.ToInt32(_dataSet.Tables[tableName].Rows[0]["id"]) + 1000000;
            DataRow newRow = _dataSet.Tables[tableName].NewRow();
            newRow.ItemArray = _dataSet.Tables[tableName].Rows[0].ItemArray;
            newRow["ID"] = (Decimal)newId;
            _dataSet.Tables[tableName].Rows.Add(newRow);
            dataAdapter.InsertCommand = cmdBuilder.GetInsertCommand();
            dataAdapter.Update(_dataSet.Tables[tableName]);
        }
