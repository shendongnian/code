    public static DataTable getDataGridList(string strCmd)
        {
            
            openConnection(conn);
            OleDbDataAdapter DADet = new OleDbDataAdapter(strCmd, conn);
            DataTable DTDet = new DataTable();
            DADet.Fill(DTDet);
            closeConnection(conn, null);
            return DTDet;
        }
