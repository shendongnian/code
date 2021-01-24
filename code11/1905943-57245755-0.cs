    [TestClass]
    public class ObjectEquivalencyTests {
        [TestMethod]
        public void ShouldBeEquivalent() {
            var orderDto = new OrderDto {
                Property1 = "https://www.google.com",
                Property2 = "something else"
            };
            var expectation = new Order {
                Property1 = "https://www.google.com/search?q=test",
                Property2 = "something else"
            };
            orderDto.Should().BeEquivalentTo(expectation, options => options
                .Using<string>(ctx => {
                    ctx.Subject.Should().StartWith("https://www.google.com");
                    ctx.Expectation.Should().Be("https://www.google.com/search?q=test");
                })
                .When(info => info.SelectedMemberPath == "Property1")
            );
        }
    }
    public class Order {
        public string Property1 { get; set; }
        public string Property2 { get;  set; }
    }
    public class OrderDto {
        public string Property1 { get; set; }
        public string Property2 { get;  set; }
    }
