    using (OleDbConnection con = new OleDbConnection(conStr))
        using (OleDbCommand com = new OleDbCommand("INSERT INTO DPMaster(DPID,DPName,ClientID,ClientName) VALUES('53','we','41','aw')", con) {
            con.Open();
                
            int a = com.ExecuteNonQuery();
            MessageBox.Show(a.ToString());
        }
