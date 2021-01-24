        [Fact]
        public void MoqTestDynamic2()
        {
            var m = new Mock<ITestInterface>();
            m.SetResult(typeof(ITestInterface).GetMethod("GetAnotherInt"), 168);
            Assert.Equal(168, m.Object.GetAnotherInt("s", 1, 3));
            Assert.Equal(168, m.Object.GetAnotherInt("p", 1, 35));
            Assert.Equal(168, m.Object.GetAnotherInt(null, 1, 3));
        }
        public interface ITestInterface
        {
            int GetInt(string s);
            int GetAnotherInt(string s, int i, long l);
        }
