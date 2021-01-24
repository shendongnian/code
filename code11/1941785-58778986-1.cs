    [Test]
    public void CrewWorks_Should_Find_By_Id() {
        //Arrange
        int expectedId = 102;
        string expectedName = "Test Joe";
        Crew expected = new Crew {
            Id = expectedId,
            Name = "Test Joe"
        };
        Mock<DbContext> ctxMock = new Mock<DbContext>();
        ctxMock
            .Setup(_ => _.Set<Crew>().Find(expcetedId))
            .Returns(expected);
        DbContext ctx = ctxMock.Object;
        CrewRepository subject = new CrewRepository(ctx);
        //Act
        Crew actual = subject.Find(expectedId);
        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
