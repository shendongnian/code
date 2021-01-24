    public async Task CreateAuto() {
        //Arrange
        var db = Substitute.For<IAutoDb>();
        //configure mock to return the passed argument
        db.Create(Arg.Any<Auto>()).Returns(_ => _.Arg<Auto>());
        var service = new AutoService(db);
        var model = new AutoModel {
            Id = new Guid(),
            Type = "Porsche",
            Name = "911 Turbo",
        };
        //Act
        var actual = await service.CreateProfile(model);
        //Assert
        Assert.IsTrue(actual is Auto);
    }
