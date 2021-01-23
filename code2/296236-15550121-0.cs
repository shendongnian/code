        public void insertSimRun(OracleConnection conn, SliceDataExchange.ServiceReference1.SimulationRun simRun)
        {
            string sqlInsert = "INSERT INTO slice_sim (runid, first_int_start, simulation_run) ";
            sqlInsert += "values (:p_runid, :p_interval_start, :p_simxml)";
            OracleCommand cmdInsertSR = new OracleCommand();
            cmdInsertSR.CommandText = sqlInsert;
            cmdInsertSR.Connection = conn;
            OracleParameter runID = new OracleParameter();
            runID.DbType = DbType.Int32;
            runID.Value = simRun.RunId;
            runID.ParameterName = "p_runid";
            OracleParameter first_interval_start = new OracleParameter();
            first_interval_start.DbType = DbType.DateTime;
            first_interval_start.Value = simRun.FirstIntervalStartUtc;
            first_interval_start.ParameterName = "p_interval_start";
            var serializer = new XmlSerializer(typeof(SliceDataExchange.ServiceReference1.SimulationRun));
            StringWriter writer = new StringWriter();
            //System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            serializer.Serialize(writer,simRun);
            //xdoc.LoadXml(writer.ToString());
            OracleParameter simRunXML = new OracleParameter();
            simRunXML.DbType = DbType.String;
            simRunXML.ParameterName = "p_simxml";
            simRunXML.Value = writer.ToString();
            simRunXML.OracleDbType = OracleDbType.XmlType;
            
            cmdInsertSR.Parameters.Add(runID);
            cmdInsertSR.Parameters.Add(first_interval_start);
            cmdInsertSR.Parameters.Add(simRunXML);
            cmdInsertSR.ExecuteNonQuery();
            cmdInsertSR.Dispose();
        }
