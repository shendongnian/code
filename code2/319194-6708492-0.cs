    public interface ITextMeasurer
        {
            SizeF MeasureString(string text, Font font, StringFormat format);
        }
    
        public class TextMeasurer : ITextMeasurer
        {
            private readonly Image _fakeImage;
            private readonly Graphics _graphics;
    
            public TextMeasurer()
            {
                _fakeImage = new Bitmap(1, 1);
                _graphics = Graphics.FromImage(_fakeImage);
            }
    
            public SizeF MeasureString(string text, Font font, StringFormat format)
            {
                return _graphics.MeasureString(text, font, int.MaxValue, format);
            }
        }
