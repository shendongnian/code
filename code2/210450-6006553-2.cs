		public static string GetEfConnectionString(this string sqlConnectionString, Type type)
		{
			string cs =
				string.Format(
					@"metadata=res://{0}/Models.Model.csdl|res://{0}/Models.Model.ssdl|res://{0}/Models.Model.msl;provider=System.Data.SqlClient;provider connection string=""" +
					sqlConnectionString + @"""",
					type.Assembly.FullName
					);
			return cs;
		}
        // usage: don't "new" EntityConnection.  See 2012 comment.
		string connString = ConfigurationManager.ConnectionStrings["sqlConnection"].ConnectionString.GetEfConnectionString();
		using(var entities = new XyzEntities(connString))
