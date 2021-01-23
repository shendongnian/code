    public class TestAsyncClass {
        public Task OperateAsync() {
            return Task.Factory.StartNew(
                () => {
                    throw new Exception("an exception is occurred.");
                }
            );
        }
    }
    [TestClass]
    public class TestAsyncClassTest {
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void OperateAsyncTest() {
            var testAsyncClass = new TestAsyncClass();
            testAsyncClass.OperateAsync().Wait();
        }
    }
