    public abstract class MyObjectDummy : IMyObject
    {
        public virtual int Id { get; set; }  
        public virtual string PropA { get; set; }
    }
    var mock = new Mock<MyObjectDummy>();
    mock.SetupSet(m => m.PropA = It.IsAny<string>()).CallBase();
    mock.SetupGet(m => m.PropA).CallBase();
    mock.Setup(m => m.Id).Returns(() => (mock.Object.PropA?.GetHashCode()).GetValueOrDefault());
    
    mock.Object.PropA = "test";
    Assert.Equal("test".GetHashCode(), mock.Object.Id);
