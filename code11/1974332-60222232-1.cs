      public abstract class MyCustomController : ApiController
      {
            /// <summary>
            /// REST Get method
            /// </summary>
            /// <param name="requestPayload">String containing a base64 serialized MyProtobufRequest object</param>
            /// <returns>String containing a base64 serialized MyProtobufReply object</returns>
            public string Get(string requestPayload)
            {
                var requestObj = ProtobufHelper.DeserializeProtobuf<MyProtobufRequest>(requestPayload);
                return (ProtobufHelper.SerializeProtobuf(GetHandler(requestObj)));
            }
    
            private MyProtobufReply GetHandler(MyProtobufRequestrequest request)
            {
               // Type your code here
               return new MyProtobufReply();
            }                
      }
