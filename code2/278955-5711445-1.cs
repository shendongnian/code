    [Test]
    public void Movie_Information_Is_Loaded_Correctly()
    {
        var mockWebRequester = new Moq.Mock<ITomatoWebRequester>();
        var myJson = "enter json response you want to use to test with here";
        mockWebRequester.Setup(a => a.GetMovieJSONByID(It.IsAny<int>())
            .Returns(myJson);
        Tomato tomato = new Tomato("t4qpkcsek5h6vgbsy8k4etxdd", 
            mockWebRequester.Object);
        var movie = tomato.FindMovieById(9818);
        movie.Title.ShouldEqual("Gone With The Wind");
    }
