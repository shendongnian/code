    private static (string TVD_LS_NO, string TVD_INV_NO) getDo(string DoNo)
    {
        //We declare our return value(s)
        var toReturn(TVD_LS_NO: "", TVD_INV_NO: "");
        using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["Oracle_To_Sql.Properties.Settings.Setting"].ToString()))
        {
            string query = "select SUBSTR(TVD_DO_ITEM_NO,'1','10') from T_VEHICLE_DTL1  where TVD_LS_NO=:TVD_LS_NO";
            OracleCommand myCommand = new OracleCommand(query, con);
            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(myCommand);
            da.SelectCommand = new OracleCommand(query, con);                    
            da.Fill(dt);                    
            foreach (DataRow row in dt.Rows)
            {
                //We assign our return values
                toReturn.TVD_LS_NO = row["TVD_LS_NO"].ToString();
                toReturn.TVD_INV_NO = row["TVD_INV_NO"].ToString();                        
            }
            return toReturn;
    }
