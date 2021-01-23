    public interface IResponse
    {
        string ResponseText { get; set; }
    }
    ...
        [Test]
        public void Test()
        {
            IResponse response = MockRepository.GenerateStub<IResponse>();
            response.ResponseText = "value1";
            Assert.AreEqual("value1", response.ResponseText);
            response.ResponseText = "value2";
            Assert.AreEqual("value2", response.ResponseText);
        }
