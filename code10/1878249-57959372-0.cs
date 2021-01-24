    [Fact]
    public void ErrorIfReadingBeforeInitialized()
    {
        var sut = new TemperatureSensor();
     
        Assert.Throws<InvalidOperationException>(() => sut.ReadCurrentTemperature());
    }
