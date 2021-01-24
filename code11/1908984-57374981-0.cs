		// To avoid storing the connection string in your code, 
		// you can retrieve it from a configuration file.
		SqlConnection myConnection = new SqlConnection("Data Source=ipaddress;
                                                      Initial Catalog=dbname;
                                                      User Id=userid; 
                                                      Password=pass;");
