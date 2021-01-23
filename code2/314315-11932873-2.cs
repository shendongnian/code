    var model = AutoMap.AssemblyOf<MyDb>()
                    .Where(t => t.Namespace.StartsWith("MyDb.Tables"))
                    .Conventions.AddFromAssemblyOf<MyDb>();
        private static ISessionFactory CreateMsSqlSessionFactory()
        {
            //AutoPersistenceModel model = CreateAutoMappings();
            AutoPersistenceModel model = CreateMappings();
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005
                .ConnectionString(c => c
                    //.Server("MYCOMPUTER\\SQLEXPRESS")
                    .Server("localhost")
                    //.Database("testdb")
                    .Database("nhDMS")
                    .Username("TableCreatorWebServices")
                    .Password(DB.Tools.Cryptography.AES.DeCrypt("AES_ENCRYPTED_PW"))))
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<SsoToken>()) 
                .Mappings(m => 
                    {
                        m.AutoMappings.Add(model);
                        m.FluentMappings.Conventions.Setup(x =>
                         {
                             //x.AddFromAssemblyOf<MyDb.Tables.T_Admin>();
                             x.Add(FluentNHibernate.Conventions.Helpers.AutoImport.Always()); // AutoImport.Never
                         }); // End FluentMappings.Conventions.Setup
                    }
                
                ) // End Mappings
                .ExposeConfiguration(BuildSchema)  // BuildSchema function call...
                .BuildSessionFactory();
        } // End Function CreateMsSqlSessionFactory
