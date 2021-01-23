    [TestMethod]
    public void ValidateAll_ReturnsADictionaryWithAFormatException_WhenOneOfTheFactsValidationThrowsAFormatException()
    {
        var anyFactOne = new Mock<ProductUnitFact>();
        var anyFactTwo = new Mock<SequenceRunFact>();
        var anyFactThree = new Mock<SourceDetails>();
        anyFactOne.Setup(f => f.Validate()).Throws(new FormatException());
        var dataWarehouseFacts = new DataWarehouseFactsForTests { Facts = new Fact[] { anyFactOne.Object, anyFactTwo.Object, anyFactThree.Object } };
        var result = dataWarehouseFacts.ValidateAll().ToList();
        
        anyFactOne.Verify(f => f.Validate(), Times.Exactly(1));
        anyFactTwo.Verify(f => f.Validate(), Times.Exactly(1));
        anyFactThree.Verify(f => f.Validate(), Times.Exactly(1));
        Assert.AreEqual(1, result.Count());
        Assert.AreEqual(typeof(FormatException), result.First().Value.GetType());
    }
