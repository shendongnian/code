    [Test]
    public async Task Get3Autos() {
        var db = Substitute.For<IAutoDb>();
        var expected = new List<Auto>() {
            new Auto(),
            new Auto(),
            new Auto(),
        };
        db.GetAll().Returns(expected);
        var service = new AutoService(db);
        //Act
        var actual = await service.GetAutos();
        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }
    [Test]
    public async Task Delete1AutoById() {
        //Arrange
        var expectedId = Guid.Parse("FF28A47B-9A87-4184-919A-FDBD414D0AB5");
        Guid actualId = Guid.Empty;
        var db = Substitute.For<IAutoDb>();
        db.Remove(Arg.Any<Guid>()).Returns(_ => {
            actualId = _.Arg<Guid>();
            return Task.CompletedTask;
        });
        var service = new AutoService(db);
        //Act
        await service.RemoveById(expectedId);
        //Assert
        Assert.AreEqual(expectedId, actualId);
    }
