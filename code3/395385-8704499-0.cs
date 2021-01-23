    var sbSql = new System.Text.StringBuilder(500);
    
    sbSql.Append("delete from X where id in (");
    
    if (lstItem.Count != 0) {
      foreach (int value in lstItem)
      {
         if (sbSql.Length != 0) 
         {
            sbSql.Append(",");
         }
         sbSql.Append(value);
      }
    
    } else {
       sbSql.Append(-1);
    }
    
    sbSql.Append(")");
    
    SqlComm.CommandText = sbSql.ToString();
