    [Test]
    public void ShouldDeleteAFileWhenItExists()
    {
        var mockInfo = MockRepository.GenerateMock<FileInfo>();
        mockInfo.Expect( i => i.Exists ).Return( true ).Repeat.Once();
        mockInfo.Expect( i => i.Delete() ).Repeat.Once();
        var extensions = new FileInfoExtensions();
        extensions.DeleteIfExists( mockInfo );
        mockInfo.VerifyAllExpectations();
    }
    [Test]
    public void ShouldNotDeleteAFileWhenItDoesNotExist()
    {
        var mockInfo = MockRepository.GenerateMock<FileInfo>();
        mockInfo.Expect( i => i.Exists ).Return( false ).Repeat.Once();
        mockInfo.Expect( i => i.Delete() ).Repeat.Never();
        var extensions = new FileInfoExtensions();
        extensions.DeleteIfExists( mockInfo );
        mockInfo.VerifyAllExpectations();
    }
