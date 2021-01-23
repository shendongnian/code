       [TestCase(".txt", "c:\test\file1.txt")]
       [TestCase(".txt", "c:\test\file2.txt")]
       [TestCase(".dat", "c:\test\file1.dat")]
       [TestCase(".dat", "c:\test\file2.dat")]
       public void Should_Copy_Text_Files(string extension, string fileName){
           var dictionary = new FakeDictionary().FakeFiles();
           var mockObject = MockRepository.GenerateMock<IFileSystemIO>();
           var systemUnderTest = new CopyFileToDestination(mockObject);
           systemUnderTest.Cpy_Files(dictionary);
           mockObject.AssertWasCalled(f => f.Copy(extension, fileName));
       }
