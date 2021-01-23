    public class ClassWithProperities
    {
        public string Foo { get; set; }
        public int Bar { get; set; }
    }
    public static class Converter
    {
        public static ClassWithProperities Convert(string foo, int bar)
        {
            return new ClassWithProperities {Foo=foo, Bar=bar};
        }
    }
    [TestClass]
    public class PropertyTests
    {
        private static ClassWithProperities classWithProperties;
        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            //Arrange
            string foo = "test";
            int bar = 1;
            //Act
            classWithProperties = Converter.Convert(foo, bar);
            //Assert
        }
        [TestMethod]
        public void AssertFooIsTest()
        {
            Assert.AreEqual("test", classWithProperties.Foo);
        }
        [TestMethod]
        public void AssertBarIsOne()
        {
            Assert.AreEqual(1, classWithProperties.Bar);
        }
    }
