    [Test]
    [ExpectedException(typeof(FileNotFoundException))]
    public void Fails_When_Csv_File_Does_Not_Exist() {
        IFileFinder finder = mockery.NewMock<IFileFinder>();
        Merger      merger = new Merger(finder);
        Stub.On(finder).Method("FileExists").Will(Return.Value(false));
        merger.Merge("csvPath", "templatePath", "outputPath");
    }
