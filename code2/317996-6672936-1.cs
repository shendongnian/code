    builder.Register(c =>
    {
        var scope = c.Resolve<ILifetimeScope>();
        var factory = c.Resolve<NHibernate.ISessionFactory>();
        return factory.OpenSession(new AutofacInterceptor(scope));
    })
    .As<NHibernate.ISession>();
