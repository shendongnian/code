    ds.Tables[7].Rows.OfType<DataRow>().ToList().ForEach(f => tempList.Add(new MyEntity
    {
      Id = int.Parse(f.ItemArray[0].ToString()),
      Title = f.ItemArray[1].ToString()
     }));
