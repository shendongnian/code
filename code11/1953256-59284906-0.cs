    public sealed class LogHandlerTests {
        
        private class Subject: SomeClass {
            public Subject(): base (null) { //<-- SHOULD THROW
                //...
            }
        }
        [Test]
        public void Constructor_Test_Should_Throw_ArgumentNulLException_When_SomeDependency_Is_Null() {
            Assert.Throws<ArgumentNullException>(() => new Subject());
        }
    }
