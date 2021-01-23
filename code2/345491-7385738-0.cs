    public static class UnitTestHelpers
            {
                public static MyModelRepository MockMyModelRepository(params Posts[] post)
                {
                    // Generate an implementer of MyModelRepository at runtime using Moq
                    var mockPosts = new Mock<MyModelRepository>();
                    mockPosts.Setup(x => x.Posts).Returns(post.AsQueryable());
                    return mockPosts.Object;
                }
        }
