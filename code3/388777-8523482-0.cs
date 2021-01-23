    public class SampleTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(...)]
        [InlineData(N)]
        public void Test(int x)
        {
            XamlTestManager.ConductTest(x);
        }
    }
