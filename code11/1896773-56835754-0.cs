    [TestFixtureSource(typeof(FixtureArgs))]
    public class SomeTestClass: BaseRepositoryTests {
        private readonly Foo _foo;
        private readonly Bar _bar;
        public SomeTestClass(Foo foo, Bar bar)  {
            _foo = foo;
            _bar = bar;
        }
        [Test]
        public async Task SomeTest() {
            //...
        }
    }
    class FixtureArgs: IEnumerable {
        public IEnumerator GetEnumerator() {
            yield return new object[] { 
                new Foo { FooId = 0, FooName= "meh" }, new Bar { Email = "test.user@google.com", FirstName = "test", Surname = "user"} 
            };
            
            yield return new object[] { 
                new Foo { FooId = 1, FooName= "meh" }, new Bar { Email = "test.user@google.com", FirstName = "test", Surname = "user"} 
            };
            //...
        }
    }
