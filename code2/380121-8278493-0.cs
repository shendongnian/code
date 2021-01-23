        SessionFactory = Fluently.Configure(configuration).Mappings(m =>
    {
        m.FluentMappings.AddFromAssemblyOf<AttachmentLocaionMap>();
        m.FluentMappings.AddFromAssemblyOf<AttachmentTypeMap>();
        m.FluentMappings.AddFromAssemblyOf<AttachmentMap>();
        m.HbmMappings.AddFromAssemblyOf<SomeTypeFromYourAssemblyWithHbmMappings>()
     }).BuildSessionFactory();
