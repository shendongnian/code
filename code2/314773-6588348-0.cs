    StringBuilder sb = new StringBuilder();
    using (SqlCommand s = new SqlCommand(sb.ToString(), conn)) {
        try 
        { 
        
            using (SqlDataReader dr = s.ExecuteReader()) {
                while(dr.Read())
                  DoSomething(dr);
            }
        
        }
        catch (Exception ex)
        { 
            sb.Append(Util.ExceptionRecursive(ex)); 
        }    
    }
