    [Fact]
    public void TestObjectSelector()
    {
        var company = new MyCompany { RegionId = 1, Name = "One" };
        var fakeBl = new FakeBusiness().For(company); // Configure mock
        var actual = fakeBl.GetCompany(c => new { c.Name }); // Wrong selector
        actual.Should().BeEquivalentTo(new { RegionId = 1 }); //Fail
    }
