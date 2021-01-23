    public class RequestSenderHelpers
    {
        public static void Send(HttpWebRequest request, AsyncCallback internalCallback, object requestState)
        {
            var result = new Mock<IAsyncResult>();
            result.Setup(x => x.AsyncState).Returns(requestState);
            internalCallback(result.Object);
        }
        
    }
        [Test]
        public void Callback_VerifyingWithMethodImplementation_VerifyWorks()
        {
            // arrange
            var sender = new Mock<IRequestSender>();
            sender.Setup(s => s.Send(It.IsAny<HttpWebRequest>(), It.IsAny<AsyncCallback>(), It.IsAny<object>())).Callback<HttpWebRequest, AsyncCallback, object>(RequestSenderHelpers.Send);
            // act
            sender.Object.Send(null, delegate {}, null);
            // assert
            sender.Verify(s => s.Send(It.IsAny<HttpWebRequest>(), It.IsAny<AsyncCallback>(), It.IsAny<object>()));
        }
