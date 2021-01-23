    If you mean DbConnection class which is in System.Data.Common namespace, then one way 
    to use it in a C# program is as follow:
    
    string CnnStr = "Data Source=local;Initial Catalog=dbTest;User Id=sa;pwd=1";
    DbConnection cnn = new SqlConnection(CnnStr);
    cnn.Open();
