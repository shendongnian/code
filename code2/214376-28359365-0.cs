    public interface IContainsMyModel
    {
        ViewModel Model { get; }
    }
    public class ViewModel : IContainsMyModel
    {
        public string MyProperty { set; get; }
        public ViewModel Model { get { return this; } }
    }
    public class Composition : IContainsMyModel
    {
        public ViewModel ViewModel { get; set; }
    }
