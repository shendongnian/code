    [TestMethod]
    [ExpectedException( typeof( InvalidOperationException ) )]
    public void YourMethod_ThrowsIOException()
    {
        var mock = new Moq<YourClass>();
        mock.Setup( obj => obj.YourMethod( It.IsAny<string>() ) ).Throws<InvalidOperationException>();
        YouClass mockedClass = mock.Object;
        mockedClass.YourMethod( "anything" );
    }
