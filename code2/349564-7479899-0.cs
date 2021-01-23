    var vrCountry = from country in objEmpDataContext.CountryMaster
                            select new {country.CountryID,country.CountryName};
    
    DataTable dt = LINQToDataTable(objEmpDataContext,vrCountry);
    
    public DataTable ToDataTable(System.Data.Linq.DataContext ctx, object query)
    {
         if (query == null)
         {
              throw new ArgumentNullException("query");
         }
         
         IDbCommand cmd = ctx.GetCommand(query as IQueryable);
         SqlDataAdapter adapter = new SqlDataAdapter();
         adapter.SelectCommand = (SqlCommand)cmd;
         DataTable dt = new DataTable("sd");
    
         try
         {
              cmd.Connection.Open();
              adapter.FillSchema(dt, SchemaType.Source); 
              adapter.Fill(dt);
         }
         finally
         {
              cmd.Connection.Close();
         }
         return dt;
    }
