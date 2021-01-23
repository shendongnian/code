    public class InvalidImageException : Exception
    {
        public InvalidImageException() { }
        public InvalidImageException(string message)
            : base(message) { }
        public InvalidImageException(string message, Exception innerException)
            : base(message, innerException) { }
        public InvalidImageException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
        public InvalidImageException(string message, MyImage image)
            : base(message) 
        {
            this.Image = image;
        }
        public MyImage Image { get; set; }
    }
