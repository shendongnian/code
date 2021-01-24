    public class UnitTest1
    {
        public enum Foo { Bar, Baz, Qux }
        [Theory]
        [InlineData(Foo.Bar, Foo.Baz)]
        public void Test1(Foo left, Foo right)
        {
            Assert.NotEqual(left, right);
        }
    }
