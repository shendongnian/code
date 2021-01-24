            DataTable dt = ds.Tables[0];
            OracleConnection oraclecon = (OracleConnection)db.Database.Connection;
            // create command and set properties  
            OracleCommand cmd = oraclecon.CreateCommand() as OracleCommand;
            cmd.CommandText = "INSERT INTO CSKH_IMPTEST_07052019 (ma_tb,ghichu) VALUES (:2, :3)";
            OracleParameter mA_TB = new OracleParameter();
            mA_TB.OracleDbType = OracleDbType.Varchar2;
            cmd.Parameters.Add(mA_TB);
            OracleParameter gHICHU = new OracleParameter();
            gHICHU.OracleDbType = OracleDbType.Varchar2;
            cmd.Parameters.Add(gHICHU);
            oraclecon.Open();
            foreach(DataRow ro in dt.Rows)
            {
                mA_TB.Value = ro["MA_TB"].ToString();
                gHICHU.Value = ro["GHICHU"].ToString();
                cmd.ExecuteNonQuery();
            }
            oraclecon.Close();
