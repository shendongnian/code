    [TestClass]
    public class MyTestClass {
        [TestMethod]
        public void UnzipData_CalledWithByteArrayParameter_ReturnsString() {
            //Arrange
            var _serializationService = new Subject();
            string expected = "[{\"ix\":1,\"ContentModel\":{\"name\":\"Dana\",\"date\":\"2016-05-06T22:26:26.0437049+02:00\",\"dateRequested\":\"2016-05-06\"}},{\"ix\":2,\"ContentModel\":{\"name\":\"Darlene\",\"visits\":1,\"date\":\"2014-09-25T05:22:33.3566479+02:00\",\"dateRequested\":\"2014-09-25\"}}]";
            byte[] array = _serializationService.ZipData(expected);
            //Act
            string actual = _serializationService.UnzipData(array);
            //Assert
            actual.Should().NotBeNull()
                .And.Be(expected);            
        }
    }
