    cmd.CommandText = text;             
    SqlParameter param = new SqlParameter("@" + Common.Data.MessageInfo.SenduseridField, Id);             
    param.SqlDbType = SqlDbType.Int;        
    cmd.Parameters.Add(param);             // you  over looked this 
        
    param = new SqlParameter("@" + Common.Data.MessageInfo.RecuseridField, Id);             
    param.SqlDbType = SqlDbType.Int;             
    cmd.Parameters.Add(param);             
    
    cmd.Connection = this.GetConnection();             
    cmd.Connection.Open(); 
