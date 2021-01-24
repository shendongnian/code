    public static class ProtobufHelper
    {
        /// <summary>
        /// Transform base64 string message to protobuf IMessage object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageBase64"></param>
        /// <returns></returns>
        public static T DeserializeProtobuf<T>(string messageBase64) where T: IMessage, new()
        {
            T result = new T();
            if (!String.IsNullOrWhiteSpace(messageBase64))
            {
                if (messageBase64.StartsWith("\"") && && messageBase64.Length > 2)
                    messageBase64 = messageBase64.Substring(1, messageBase64.Length - 2);
                result.MergeFrom(ByteString.FromBase64(messageBase64));
            }
            return (result);
        }
        /// <summary>
        ///  Transform protobuf IMessage object to base64 string message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string SerializeProtobuf(IMessage message)
        {
            return (message.ToByteString().ToBase64());
        }
    }
