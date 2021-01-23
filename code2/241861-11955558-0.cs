    using System;
    using System.Runtime.Serialization;
    
    namespace YourNamespaceHere
    {
        [Serializable()]
        public class YourCustomException : Exception, ISerializable
        {
            public YourCustomException() : base() { }
            public YourCustomException(string message) : base(message) { }
            public YourCustomException(string message, System.Exception inner) : base(message, inner) { }
            public YourCustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        }
    }
