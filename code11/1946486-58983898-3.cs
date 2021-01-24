    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public void MyTestMethod() {
            //Arrange
            XElement element = new XElement("root",
                new XAttribute("MyProperty1", "Hello World"),
                new XAttribute("MyEnumProperty", "Value2")
            );
            //Act
            var mock = DeserializeMock<MyClass>(element);
            //Assert
            var actual = mock.Object;
            actual.MyEnumProperty.Should().Be(MyEnum.Value2);
            actual.MyProperty1.Should().Be("Hello World");
        }
        public class MyClass {
            public virtual string MyProperty1 { get; set; }
            public virtual MyEnum MyEnumProperty { get; set; }
        }
        public enum MyEnum {
            Value1,
            Value2
        }
        //...
    }
