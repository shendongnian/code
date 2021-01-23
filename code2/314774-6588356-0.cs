    sb = new StringBuilder();
    ...
    using (SqlCommand s = new SqlCommand(sb.ToString(), conn))
    using (SqlDataReader dr = s.ExecuteReader())
    {
        try
        {
            while(dr.Read())
              DoSomething(dr);
        }
        catch (Exception ex)
        { 
            sb.Append(Util.ExceptionRecursive(ex)); 
        }
    }
