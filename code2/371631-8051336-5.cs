        [Serializable]
        public class StackEmptyException :
            InvalidOperationException
        {
		    // This constructor is internal, it means, only the assembly that contains this exception can throw it.
			// In C# there is not the "friend" keyword like in C++ so we can just use internal.
            internal StackEmptyException() :
                base("Cannot pop an item from an empty stack")
            {
            }
            /// <summary>Used for serialization. Never forget it!</summary>
            protected StackEmptyException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
            {
            }
        }
