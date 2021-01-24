    [Fact]
    public async Task Get3Autos() {
        var db = new TestAutoDb();
        // Add 3 autos
        var firstGuid = new Guid(1, 2, 3, new byte[] { 4, 5, 6, 7, 8, 9, 10, 11 });
        db.Autos = new List<Auto> {
            new Auto { Id = firstGuid, Name = "Abc" },
            new Auto { Id = Guid.NewGuid(), Name = "Def" },
            new Auto { Id = Guid.NewGuid(), Name = "Ghi" }
        };
        var service = new AutoService(db);
        // Check service layer (note: just delegates to IAutoDb, so not a very useful test)
        var result = await service.GetAutoById(firstGuid);
        Assert.Equal(db.Autos[0], result);
    }
