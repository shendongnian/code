    string strDSN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Db1.accdb";
    string strSQL = "SELECT * FROM Tbl1" ;
    // create Objects of ADOConnection and ADOCommand
    OleDbConnection myConn = new OleDbConnection(strDSN);
    OleDbDataAdapter myCmd = new OleDbDataAdapter( strSQL, myConn ); 
    myConn.Open();
    DataSet dtSet = new DataSet();
    myCmd.Fill( dtSet, "Tbl1" );
    DataTable dTable = dtSet.Tables[0];
    foreach( DataRow dtRow in dTable.Rows )
    {
        listBox1.Items.Add( dtRow["id"].ToString());
        listBox2.Items.Add( dtRow["nm"].ToString());
        listBox3.Items.Add(dtRow["ag"].ToString());
    }
