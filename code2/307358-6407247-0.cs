    [ComVisible(true)]
    public interface ITestEntity1
    {
        string Name { get; set; }
        ITestEntity2 Entity2 { get; set; }
    }
    [ComVisible(true)]
    public class TestEntity1 : ITestEntity1
    {
        public string Name { get; set; }
        public ITestEntity2 Entity2 { get; set; }
    }
