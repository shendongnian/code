     while (puanoku.Read())
     {
      for(int i = 0; i < puanoku.FieldCount)
      {
          puann.Add(puanoku.GetInt32(i));
      }
     }
