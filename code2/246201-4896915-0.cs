    [TestMethod]
    [ExpectedException(typeof(FileNotFoundException), "Raise exception when file not found")]
    public void VerifyBuildMachineNamesIfFileNotPresent()
    {
        var configReaderNoFile = new ConfigReader();
        var names = configReaderNoFile.GetBuildMachineNames("unexistent.xml");
    }
