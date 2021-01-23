    public interface XExposer
    {
        Int32 X { get; }
    }
    public class TestClass : XExposer
    {
        public Int32 X { get { return 5;} }
    }
    public class XExposerWrapper<T> where T : XExposer, new()
    {
        public Int32 X
        {
            get { return new T().X; }
        }
    }
