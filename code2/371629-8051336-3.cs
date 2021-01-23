        [Serializable]
        public class StackEmptyException :
            InvalidOperationException
        {
            public StackEmptyException() :
                base("Cannot pop an item from an empty stack")
            {
            }
            public StackEmptyException(string message) :
                base(message)
            {
            }
            /// <summary>Used for serialization. Never forget it!</summary>
            protected StackEmptyException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
            {
            }
        }
