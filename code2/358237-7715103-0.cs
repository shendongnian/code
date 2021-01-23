        [TestMethod]
        public void IValueConverter()
        {
            var myStub = new Mock<IValueConverter>();
            myStub.Setup(conv => conv.Convert(It.IsAny<object>(), It.IsAny<Type>(), It.IsAny<object>(), It.IsAny<CultureInfo>())).
                Returns((object one, Type two, object three, CultureInfo four) => (int)one + 5);
            var value = 5;
            var expected = 10;
            var actual = myStub.Object.Convert(value, null, null, null);
            Assert.AreEqual<int>(expected, (int) actual);
        }
