    [TestClass]
    public class ObjectEquivalencyTests {
        [TestMethod]
        public void ShouldBeEquivalent() {
            var expected = new MyObject {
                Property1 = "https://www.google.com",
                Property2 = "something else"
            };
            var actual = new MyObject {
                Property1 = "https://www.google.com/search?q=test",
                Property2 = "something else"
            };
            actual.Should().BeEquivalentTo(expected, options => options
                .Using<string>(ctx => ctx.Subject.Should().StartWith(ctx.Expectation))
                .When(info => info.SelectedMemberPath == "Property1")
            );
        }
    }
    public class MyObject {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
