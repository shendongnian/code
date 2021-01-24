    public class AuditCheck
    {        
        public AuditCheck(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void MyTest()
        {
            var expected = 23;
            var actual = 42;
            try
            {
                Assert.Equal(expected, actual);
            }
            catch (XunitException e)
            {
                output.WriteLine($"My own output, like filename, etc. Today is {DateTime.Today.DayOfWeek} and i expected {expected} but got {actual}");
                throw e;
            }
            Assert.Equal(expected, actual);
        }
    }
