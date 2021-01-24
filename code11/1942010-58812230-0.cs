    var connection = getConnectionFromPool(sourceOrDC);
    
    try {
       lock ( connection ) {
          using ( SqlCommand command = new SqlCommand(sql, connection) ) {
             command.CommandType = CommandType.Text;
    
             if ( paramList != null ) {
                foreach ( DictionaryEntry param in paramList ) {
                   command.Parameters.AddWithValue(param.Key.ToString(), param.Value);
                }
             }
    
             command.CommandTimeout = 0;
             command.ExecuteNonQuery();
          }
       }
                
       return true;
    }
