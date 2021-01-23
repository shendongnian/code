    <add key="strAccessConnectionString" value="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\castonmr\Documents\"Your AccessDB Name.mdb";Mode='Share Exclusive';Jet OLEDB:Database Password="your password";"/>    
    try
    {
    	OleDbConnection oleconn = null;
    	OleDbDataReader reader = null;
    	oleconn = new OleDbConnection(strAccessConnectionString);
    	oleconn.Open();
    	using (OleDbCommand cmd = new OleDbCommand())
    	{
       	   cmd.Connection = oleconn;
     	   cmd.CommandText = query;
           cmd.CommandType = CommandType.Text;
    	   reader = cmd.ExecuteReader();
    	}
    }//try
    catch (Exception ex)
    {
    	Console.WriteLine(ex.Message);
    }
