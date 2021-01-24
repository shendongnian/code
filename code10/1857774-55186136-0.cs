    public static class FormatterDimensions
    {
        public const int DEFAULT_BARCODE_WIDTH = 148;
        public const int DEFAULT_BARCODE_HEIGHT = 20;
    }
    public interface IMyFormatter
    {
        Bitmap Generate(
            string number,
            int width = FormatterDimensions.DEFAULT_BARCODE_WIDTH,
            int height = FormatterDimensions.DEFAULT_BARCODE_HEIGHT);
    }
