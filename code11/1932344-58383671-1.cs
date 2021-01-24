        [Fact]
        public void Test()
        {
            var mock = new Mock<IRestClient>();
            var spy = new List<Parameter>();
            mock
                .Setup(m => m.DefaultParameters.Add(It.IsAny<Parameter>()))
                .Callback((Parameter p) => spy.Add(p));
            var instance = mock.Object;
            instance.AddDefaultParameter(new Parameter("Foo", "Bar", ParameterType.Cookie));
            Assert.Equal("Bar", spy.Single().Value);
        }
