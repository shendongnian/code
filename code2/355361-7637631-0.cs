     public IEnumerable<MyPOCO> MapSet(IDataReader reader)
     {
         while(reader.Read())
         yield return new MyPOCO()
                    { 
                         ID = reader.GetInt(0),
                         Name = reader.GetString(1) 
                    };
     }
