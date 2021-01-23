        private ApplicationDataObjectContext m_context;
        public ApplicationDataObjectContext Context
        {
            get
            {
                if (this.m_context == null)
                {
                    string connString =
                        System.Web.Configuration.WebConfigurationManager
                        .ConnectionStrings["_IntrinsicData"].ConnectionString;
                    EntityConnectionStringBuilder builder = new EntityConnectionStringBuilder();
                    builder.Metadata =
                        "res://*/ApplicationData.csdl|res://*/ApplicationData.ssdl|res://*/ApplicationData.msl";
                    builder.Provider =
                        "System.Data.SqlClient";
                    builder.ProviderConnectionString = connString;
                    this.m_context = new ApplicationDataObjectContext(builder.ConnectionString);
                }
                return this.m_context;
            }
        } 
