    public object GetIDForMaritalStatusDesc(string msd){
      if(string.IsNullOrEmpty(msd))
        return DBNull.Value;
      using(SqlCommand sq = new SqlCommand(
        "connstr here", 
        "SELECT ID FROM MaritalStatusWHERE Desc = @msd"
      );){
        sq.Parameters.AddWithValue("@msd", msd); //note: google "can we stop using addwithvalue already"
        try{ 
          return sq.ExecuteScalar();
        } catch {
          return DBNull.Value
        }
      }
    }
