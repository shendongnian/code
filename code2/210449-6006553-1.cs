        public static EntityConnection GetEfConnectionString(this string sqlConnectionString)
        {
            var cs = string.Format(@"metadata=res://{0}/Repositories.EntityFramework.Model.csdl|res://{0}/Repositories.EntityFramework.Model.ssdl|res://{0}/Repositories.EntityFramework.Model.msl;provider=System.Data.SqlClient;provider connection string=""" + sqlConnectionString + @"""",
                Assembly.GetCallingAssembly().FullName
            );
            return new EntityConnection(cs);
        }
