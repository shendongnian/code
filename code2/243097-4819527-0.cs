    using (
                    var sqlCommand = new SqlCommand(
                        "storedprocname",
                        new SqlConnection("connectionstring"))
                        { CommandType = CommandType.StoredProcedure })
                {
              // do what you should.. setting params executing etc etc. 
    
    }
