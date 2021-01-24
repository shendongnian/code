    public abstract class TestBaseLayer<T> where T : TestBase<T>
    {
        public abstract List<T> Tests { get; set; }
    }
    public abstract class TestBase<T> where T: TestBase<T>
    {
        public TestBaseLayer<T> BaseLayer { get; set; }
        public TestBase(TestBaseLayer<T> layer)
        {
            BaseLayer = layer;
        }
    }
    public class TestPoint : TestBase<TestPoint>
    {
        public TestPoint(TestPointLayer layer) : base(layer)
        {
            layer.Tests.Add(this);
        }
    }
    public class TestPointLayer : TestBaseLayer<TestPoint>
    {
        public override List<TestPoint> Tests { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var list = new TestPointLayer();
            var test1 = new TestPoint(list);
            var test2 = new TestPoint(list);
            Debug.WriteLine(list.Tests.Count);
            // 2
        }
    }
