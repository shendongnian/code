    public static IEnumerable<T> Enumerate<T>(this T reader) where T: IDataReader 
    { 
       using(reader) 
          while(reader.Read()) 
             yield return reader; 
    } 
    public void Test()
    {
      var Res =
        from Dr in MyDataReader.Enumerate()
        select new {
          ID = (Guid)Dr["ID"],
          Description = Dr["Desc"] as string
        };
    }
