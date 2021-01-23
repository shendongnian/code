    [Test]
    [ExpectedException(typeof(System.IO.FileNotFoundException))]
    public void MyFileType_CreationWithNonexistingPath_ExceptionThrown()
    {
        String nonexistingPath = "C:\\does\\not\\exist\\file.ext";
        var mock = new Mock<MyFileType>(nonexistingPath);
        try
        {
            var target = mock.Object;
        }
        catch(TargetInvocationException e)
        {
            if (e.InnerException != null)
            {
                throw e.InnerException;
            }
            throw;
        }
    }
