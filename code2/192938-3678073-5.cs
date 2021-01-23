    [Test]
    public void LoadFile_DataLoaded_Succefully()
    {
        // Arrange
        var expectedProvider = new XmlDataProvider();
        string validFileName = CreateValidFileName();
        var data = CreateNewLocalizationData(expectedProvider);
 
        // Act
        var actualProvider = data.LoadFile(validFileName);
        // Assert
        Assert.AreEqual(expectedProvider, actualProvider);
    }
    private static LocalizationData CreateNewLocalizationData(
        XmlDataProvider expectedProvider)
    {
        return new LocalizationData(FakeXmlDataProviderFactory()
        {
            ProviderToReturn = expectedProvider
        });
    }
    private static string CreateValidFileName()
    {
        return "d:/azeri.xml";
    }
