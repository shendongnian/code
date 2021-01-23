    [Test]
    public void Output_and_reference_parameters_can_be_configured()
    {
        var fake = A.Fake<IDictionary<string, string>>();
        string ignored = null;
                
        A.CallTo(() => fake.TryGetValue("test", out ignored))
            .Returns(true)
            .AssignsOutAndRefParameters("foo");
        // This would of course be within you SUT.
        string outputValue = null;
        fake.TryGetValue("test", out outputValue);
    
        Assert.That(outputValue, Is.EqualTo("foo"));
    }
