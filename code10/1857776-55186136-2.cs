    public interface IMyFormatter
    {
        Bitmap Generate(string number, int? width = null, int? height = null);
    }
    public class DefaultFormatter : IMyFormatter
    {
        private const int DEFAULT_BARCODE_WIDTH = 148;
        private const int DEFAULT_BARCODE_HEIGHT = 20;
        public Bitmap Generate(string number, int? width = null, int? height = null)
        {
            int actualWidth = width ?? DEFAULT_BARCODE_WIDTH;
            int actualHeight = height ?? DEFAULT_BARCODE_HEIGHT;
            // Use actualWidth and actualHeight in your code
        }
    }
