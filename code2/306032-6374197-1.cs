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
          cmdIns.Parameters.Add("@name", mc[i].a);
          cmdIns.Parameters.Add("@information", mc[i].b);
          cmdIns.Parameters.Add("@other", mc[i].c);
          cmdIns.ExecuteNonQuery();
        }
        scope.Complete();    
      }
    }
