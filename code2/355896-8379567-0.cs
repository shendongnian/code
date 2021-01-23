    enum Colors
    {
        Red,
        Blue
    }
    public interface IColor
    { }
    public class Red : IColor
    { }
    public class Blue : IColor
    { }
    class Test
    {
        private readonly StandardKernel _kernal;
        public Test()
        {
            _kernal = new StandardKernel();
            _kernal.Bind<IColor>().To<Red>().WithMetadata("color", Colors.Red);
            _kernal.Bind<IColor>().To<Blue>().WithMetadata("color", Colors.Blue);
        }
        public IColor TestMethod(Colors color)
        {
            return _kernal.Get<IColor>(m => m.Get<Colors>("color") == color);
        }
    }
    [TestFixture]
    public class TestMetadataFunctions
    {
        [Test]
        public void test_method_should_return_specified_color()
        {
            var test = new Test();
            var color = test.TestMethod(Colors.Red);
            Assert.IsInstanceOf(typeof(Red), color);
        }
    }
