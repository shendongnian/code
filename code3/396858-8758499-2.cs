    [Test]
    public void Cpy_Files_ShouldCopyAllFilesInDictionary(){
		// Arrange
		var mockObject = MockRepository.GenerateMock<IFileSystemIO>();
		var systemUnderTest = new CopyFileToDestination(mockObject);
		
		// Act
		systemUnderTest.Cpy_Files(dictionary);
		
		// Assert
		
		// I know how many objects are in my fake dictionary so I set the times to repeat as a const
		const int timesToRepeat = 4;
		
		// now I just set the values below. I am not testing file names so the test will ignore arguments
		mockObject.AssertWasCalled(f => f.Copy("",""), options => options.Repeat.Times(timesToRepeat).IgnoreArguments());
    }
