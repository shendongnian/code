    [Test, TestCaseSource(typeof(FakeDictionary), "TestFiles")]
    public void Cpy_Files_ShouldCopyAllFilesInDictionary(string extension, string fielName)    {
		// Arrange
		var mockObject = MockRepository.GenerateMock<IFileSystemIO>();
		var systemUnderTest = new CopyFileToDestination(mockObject);
		
		// Act
		systemUnderTest.Cpy_Files(dictionary);
		
		// Assert
		mockObject.AssertWasCalled(f => f.Copy(extension, fileName));
    }
