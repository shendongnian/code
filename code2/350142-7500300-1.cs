    string connectionString = 
          "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\docs\\some.mdb";
    OleDbConnection con = new OleDbConnection(connectionString);
    con.Open();
    //Number of restriction columns: 5
    //Restriction columns: TABLE_CATALOG, TABLE_SCHEMA, INDEX_NAME, TYPE, TABLE_NAME
                
    string[] restrictions = new string[5];
    restrictions[2] = "SomeKey";
    restrictions[4] = "SomeTable";
    
    System.Data.DataTable table = con.GetSchema("Indexes",restrictions);
