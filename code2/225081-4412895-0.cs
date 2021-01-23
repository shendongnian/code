    [Test] public void CollectionCountShouldBeGreaterThanZero() {
      // arrange
      string tempDir = Path.GetTempPath();
      var fileInfo = new FileInfo(tempDir + Path.DirectorySeparatorChar + "test.zip");
      File.WriteAllBytes(fileInfo.FullName, Resources.TestZipFile);
      SevenZipBase.SetLibraryPath(@"c:\7z.dll");
      // act
      ReadOnlyCollection<string> collection;
      using(var archive = new SevenZipExtractor(fileInfo.FullName))
        collection = archive.ArchiveFileNames;
      // assert
      Assert.IsTrue(collection.Count > 0);
    }
