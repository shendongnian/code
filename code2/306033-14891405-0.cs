    void WriteToBase(List<MyClass> mc)
    {
      //Create Connection
      using (TransactionScope scope = new TransactionScope())
      {
        string sqlIns = "INSERT INTO table (name, information, other) 
                         VALUES (@name, @information, @other)";
    
        SqlCommand cmdIns = new SqlCommand(sqlIns, Connection);
    
        for(int i=0;i<mc.Count;i++)
        {
          cmdIns.Parameters.AddWithValue("@name", mc[i].a);
          cmdIns.Parameters.AddWithValue("@information", mc[i].b);
          cmdIns.Parameters.AddWithValue("@other", mc[i].c);
          cmdIns.ExecuteNonQuery();
          cmdIns.Parameters.Clear();
        }
        scope.Complete();    
      }
    }
