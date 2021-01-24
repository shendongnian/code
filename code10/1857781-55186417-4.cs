    public interface IMyFormatter
    {
        object Generate(string number, int? width = null, int? height = null);
    }
    public class DefaultFormatter : IMyFormatter
    {
        private const int DEFAULT_BARCODE_WIDTH = 148;
        private const int DEFAULT_BARCODE_HEIGHT = 20;
        private const string DEFAULT_BARCODE_TYPE = "TYPE.CODE128";
        public object Generate(string Number, int? Width = DEFAULT_BARCODE_WIDTH, int? Height = DEFAULT_BARCODE_HEIGHT)
        {
            Console.WriteLine(Number);
            Console.WriteLine(Width);
            Console.WriteLine(Height);
            return new object();
        }
    }
