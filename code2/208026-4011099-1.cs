    public class InvalidImageException : Exception
    {
        public InvalidImageException(MyImage image)
        {
            //Do validations here, set the message to whatever you want based on the image.
            //The property you are after is base.Message
        }
    }
