    using (var context = new DBEntities())
    {
         string query = $"Exec [dbo].[YOUR_SP]";
         List<ResponseList> obj = context.Database.SqlQuery<ResponseList>(query).ToList();
         string JSONString = JsonConvert.SerializeObject(obj);
    }
