    [Test]
    public void TestThatReadCrewWorks() {
        int expectedId = 102;
        string expectedName = "Test Joe";
        Crew expected = new Crew {
            Id = expectedId,
            Name = "Test Joe"
        };
        //Assuming abstraction of specific repository 
        //  interface ICrewPrepsitory: IRepository<Crew> { }
        ICrewPrepsitory repository = Mock.Of<ICrewPrepsitory>(_ =>
            _.Read(expectedId) == expected
        );
        CrewLogic logic = new CrewLogic(repository); //assuming injection
        //Act
        var actual = logic.LReadCrew(expectedId);
        //Assert
        Assert.That(actual.Name, Is.EqualTo(expectedName));
        //...other assertions
    }
