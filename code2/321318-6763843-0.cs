    [Test]
    public void ReadSequence_FiveA_ReturnsProperList()
    {
      // Arrange
        string sequenceStub = "AAAAA";
        int expectedCount;
        
        // Act
        MyFileDecoder decoder = new MyFileDecoder();
        List<string> results = decoder.ReadSequence(sequenceStub);
        
        // Assert
        Assert.AreEqual(5, results.Count);
        Assert.AreEqual("A", results[0]);
    }
