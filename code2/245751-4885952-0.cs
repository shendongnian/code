    var factory = AutoPoco.AutoPocoContainer.Configure(x =>
    {
        x.Conventions(c =>
        {
            c.UseDefaultConventions();
        });
        x.Include<DataRowWrapper>()
            .Setup(row => row.Timestamp).Use<DateTimeUniqueSource>()
            .Setup(row => row.Name).Use<LastNameSource>()
            .Setup(row => row.Value).Use<ApproximateNumberSource<decimal>>()
            .Setup(row => row.Description).Use<RandomReadableStringSource>(10, 20);
    });
    var session = factory.CreateSession();
    var sampleRows = session.List<DataRowWrapper>(1000).Get();
