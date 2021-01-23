    public class FontListBox : ListBox
    {
        private List<Font> _fonts = new List<Font>();
        private Brush _foreBrush;
    
        public FontListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 20;
            foreach (FontFamily ff in FontFamily.Families)
            {
                // determine the first available style, as all fonts don't support all styles
                FontStyle? availableStyle = null;
                foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                {
                    if (ff.IsStyleAvailable(style))
                    {
                        availableStyle = style;
                        break;
                    }
                }
    
                if (availableStyle.HasValue)
                {
                    Font font = null;
                    try
                    {
                        // do your own Font initialization here
                        // discard the one you don't like :-)
                        font = new Font(ff, 12, availableStyle.Value);
                    }
                    catch
                    {
                    }
                    if (font != null)
                    {
                        _fonts.Add(font);
                        Items.Add(font);
                    }
                }
            }
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (_fonts != null)
            {
                foreach (Font font in _fonts)
                {
                    font.Dispose();
                }
                _fonts = null;
            }
            if (_foreBrush != null)
            {
                _foreBrush.Dispose();
                _foreBrush = null;
            }
        }
    
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                if (_foreBrush != null)
                {
                    _foreBrush.Dispose();
                }
                _foreBrush = null;
            }
        }
    
        private Brush ForeBrush
        {
            get
            {
                if (_foreBrush == null)
                {
                    _foreBrush = new SolidBrush(ForeColor);
                }
                return _foreBrush;
            }
        }
    
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index < 0)
                return;
    
            e.DrawBackground();
            e.DrawFocusRectangle();
            Rectangle bounds = e.Bounds;
            Font font = (Font)Items[e.Index];
            e.Graphics.DrawString(font.Name, font, ForeBrush, bounds.Left, bounds.Top);
        }
    }
