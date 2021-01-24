    [Fact()]
    public void GetCountriesValues_TestCountriesReturn()
    {
        var actual = mcTest.GetCountriesValues();
        Xunit.Assert.NotEmpty(actual);
    }
