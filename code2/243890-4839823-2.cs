    [TestMethod]
    public void PostsController_Index_Action_Should_Fetch_All_Posts_From_Repository()
    {
        // arrange
        var postsRepositoryStub = MockRepository.GenerateStub<IPostsRepository>();
        var sut = new PostsController(postsRepositoryStub);
        var expectedPosts = new Post[0];
        postsRepositoryStub.Stub(x => x.GetAllPosts).Return(expectedPosts);
    
        // act
        var actual = sut.Index();
    
        // assert
        actual
            .AssertViewRendered()
            .WithViewData<IEnumerable<Post>>()
            .ShouldBe(expectedPosts);
    }
