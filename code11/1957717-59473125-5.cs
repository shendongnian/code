    using Xunit;
    using Moq;
    namespace ATestNamespace
    {
    public class TestFixture
    {
      
        public TestFixture()
        {
           
        }
        [Fact]
        public void Test()
        {
            
            Mock<IPostRepository> postRepositoryMock = new Mock<IPostRepository>();
    
            PostController controller = new PostController(postRepositoryMock.Object);
    
            postRepositoryMock.Setup(it => it.Get(It.IsAny<int?>()).Returns(new Post() { //here what you need to build your post object });
    
            var result = controller.GetPost(1);
            Assert.True(result != null,"Unexpected null result");
            var retrievedPostResult = result as OkNegotiatedContentResult<Post>;
            Assert.True(retrievedPostResult != null, "Unexpected null retrievedPost");
    
            var retrievedPost = result.Content;
            Assert.True(retrievedPost.Id == 1, "retrievedPost.Id is unexpected")
        }
    }
    }
    
