    public override list<result> retrunsearch(string search)
    {
      string[] search = pQuery.Split(',');
      List <result> myresult = new List<result>();
    
      // Build WHERE
      for (int i = 1; i < search.Length; i++)
        where += " And '%" + search[i] + "%'";
    
      // Now search
      OleDbCommand sqlcmdCommand0 = new OleDbCommand("select Distinct name from table1 where     search like '%" + search[0] + "%' " + where + " order by name", sqlcon);
      sqlcmdCommand0.CommandType = CommandType.Text;
      OleDbDataReader sdaResult0 = sqlcmdCommand0.ExecuteReader();
      while (sdaResult0.Read())
      {
        result restult1= new result();
        result1.name   = sdaResult0.String(0);
        result.add(result1);
      }
      sdaResult0.Close();
    
      return result;
    }
