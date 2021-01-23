    public class ProgressBarDirectRender : UserControl
    {
        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("value");
                _value = value;
                const int margin = 1;
                using (var g = CreateGraphics())
                {
                    if (_value == 0)
                        ProgressBarRenderer.DrawHorizontalBar(g, ClientRectangle);
                    else
                    {
                        var rectangle = new Rectangle(ClientRectangle.X + margin,
                                                      ClientRectangle.Y + margin,
                                                      ClientRectangle.Width * _value / 100 - margin * 2,
                                                      ClientRectangle.Height - margin * 2);
                        ProgressBarRenderer.DrawHorizontalChunks(g, rectangle);
                    }
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, ClientRectangle);
        }
    }
