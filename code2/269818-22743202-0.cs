    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    EntitySetConfiguration<Registration> EntitySetConfiguration_Registration = builder.EntitySet<Registration>("Registration");
    EntitySetConfiguration<Lead> EntitySetConfiguration_Lead = builder.EntitySet<Lead>("Lead");
    EntitySetConfiguration<Session> EntitySetConfiguration_Session = builder.EntitySet<Session>("Session");
    EntitySetConfiguration_Registration.EntityType.HasKey(p => p.Registration_Id);
    EntitySetConfiguration_Lead.EntityType.HasKey(p => p.Lead_Id);
    EntitySetConfiguration_Session.EntityType.HasKey(p => p.Session_Id);
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
