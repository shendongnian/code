    using System;
    using System.Data;
    using System.Data.OleDb;
    class OleDbConnectionOracle
    {
       public static void Main()
      {
        string connectionString = "provider=MSDAORA;data source=ORCL;user id=SCOTT;password=TIGER";
    OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
    OleDbCommand myOleDbCommand = myOleDbConnection.CreateCommand();
    myOleDbCommand.CommandText = "SELECT empno, ename, sal FROM emp WHERE empno = 7369";
    myOleDbConnection.Open();
    OleDbDataReader myOleDbDataReader = myOleDbCommand.ExecuteReader();
    myOleDbDataReader.Read();
    myOleDbDataReader.Close();
    myOleDbConnection.Close();
  }
}
