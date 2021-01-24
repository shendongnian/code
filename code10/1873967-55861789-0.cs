    public class Example
    {
        public bool IsValid { get; set; }
    }
    
    public interface IExample
    {
        bool Do(Example e);
    }
    // arrange
    Expression<Func<IExample, bool>> expr = m => m.Do(It.Is<Example>(x => x.IsValid));
    var mock = new Mock<IExample>();
    mock.Setup(expr).Verifiable();
    
    // act
    var example = new Example {IsValid = true};
    mock.Object.Do(example);
    example.IsValid = false;
    
    // assert
    mock.Verify(expr, Times.Once);
