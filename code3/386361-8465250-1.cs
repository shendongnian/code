        public List<ppControls> getControls(int _id)
    {
        List<ppControls> objAllControls = new List<ppControls>();
        OracleConnection conn = new OracleConnection(_strConn);
        OracleCommand cmd = new OracleCommand("SELECT * FROM controls WHERE reference =: parID", conn);
        cmd.Parameters.AddWithValue(":parID", _id);
        try
        {
            conn.Open();
            //string strCmd = parSelect;
            //OracleCommand cmd = new OracleCommand(strCmd, conn);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {                objCon.ppCustSurvey = dr["controls_content"].ToString();}
            return objAllControls;
        }
