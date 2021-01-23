            string sql = "SELECT max(tallynumber) from "+frmSchemas.schema + ".tallies" ;
             MessageBox.Show(sql);
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            MessageBox.Show("1");
            if (dr.Read())
            {
            Int64 TallyNo = dr.GetInt32(0); 
            }
