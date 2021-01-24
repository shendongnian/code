//using System.Data;
string connectionStringd1 = "Data Source=ServerName;" + "Initial Catalog=d1;" + "User id=ui;" + "Password=pd;";
string procName = "MyProcedureName";
DataTable myTable = new DataTable();
myTable = SqlToDT(connectionStringd1, procName);
//continue on from here
