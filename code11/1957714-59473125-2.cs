    using Moq;
    
    [TestFixture]
    public class ExampleFixture()
    {
        [Test]
        public void ExampleTest()
        { 
            Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
    
            PostController controller = new PostController(postRepositoryMock.Object);
    
            postRepositoryMock.Setup(it => it.Get(It.IsAny<int?>()).Returns(new Post() { //here what you need to build your post object })
            var result = controller.GetPost(1);
    
            Assert.That(result, Is.Not.Null, "Unexpected null result");
            var retrievedPost = result as OkNegotiatedContentResult<Post>;
            Assert.That(retrievedPost, Is.Not.Null, "Unexpected null retrievedPost");
            Assert.That(retrievedPost.Id, Is.EqualTo(1), "retrievedPost.Id is unexpected")
        }
    }
