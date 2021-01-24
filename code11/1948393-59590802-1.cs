    [Fact]
    public async Task MyTest() {
       var myItemRepository = A.Fake<IMyItemRepository>();
    
       A.CallTo(       () => myRepository.GetAll())
        .ReturnsLazily(() => new TestAsyncEnumerable<MyItem>(new List<MyItem> { new MyItem(), ... }));
       //////////////////
       /// ACT & ASSERT
       ////////
    }
