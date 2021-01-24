c#
[TestMethod]
public void CheckForSpamJob_ShouldBeEnqueued()
{
    // Arrange
    var client = new Mock<IBackgroundJobClient>();
    var controller = new HomeController(client.Object);
    var comment = CreateComment();
    // Act
    controller.Create(comment);
    // Assert
    client.Verify(x => x.Create(
        It.Is<Job>(job => job.Method.Name == "CheckForSpam" && job.Args[0] == comment.Id),
        It.IsAny<EnqueuedState>());
}
source: https://docs.hangfire.io/en/latest/background-methods/writing-unit-tests.html
