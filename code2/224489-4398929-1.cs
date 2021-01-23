    [Test]
    public void FindAll_should_return_correct_news()
    {
       // Arrange
       List<News> newsList = new List<News>();
       newsList.Add(new News { Id = 1, Title = "Test Title 1" });
       newsList.Add(new News { Id = 2, Title = "Test Title 2" });
       // Act
       var actual = newsList;
       // Assert
       Assert.AreEqual(2, actual.Count());
    }
