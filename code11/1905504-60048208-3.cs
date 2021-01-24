    [Test]
    public async Task Should_assert_something()
    {
        ///Arrange
        // I had issues with unit test seeing log events from other tests running at the same time so I recreate context in each test now
        using (TestCorrelator.CreateContext())
        using (var logger = new LoggerConfiguration().WriteTo.Sink(new TestCorrelatorSink()).Enrich.FromLogContext().CreateLogger())
        {
            Log.Logger = logger;
            /*...*/
            /// Act
            Task<T> task = await FooAsync(/*...*/)
            /*...*/
    
            /// Assert 
            TestCorrelator.GetLogEventsFromCurrentContext().Should().ContainSingle().Which.MessageTemplate.Text.Should().Be("foobar");
        }
    }
