c#
public class TransparentPanel : Panel
{
    public TransparentPanel()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.SupportsTransparentBackColor |
            ControlStyles.UserPaint, true);
        UpdateStyles();
    }
    public TransparentPanel(Image img) : this()
    {
        image = img;
    }
    public Image image { get; set; }
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
        //base.OnPaintBackground(pevent);
    }
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        var g = pevent.Graphics;
        if (Parent != null)
        {
            Rectangle rect = new Rectangle(Left, Top, Width, Height);
            g.TranslateTransform(-rect.X, -rect.Y);
            try
            {
                using (PaintEventArgs pea =
                            new PaintEventArgs(g, rect))
                {
                    pea.Graphics.SetClip(rect);
                    InvokePaintBackground(Parent, pea);
                    InvokePaint(Parent, pea);
                }
            }
            finally
            {
                g.TranslateTransform(rect.X, rect.Y);
            }
        }
        if (image != null)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            var rectSrc = new Rectangle(0, 0, image.Width, image.Height);
            var rectDes = new Rectangle(0, 0, Width, Height);
            //if (State == MouseState.Over)
            rectDes.Inflate(2, 2);
            g.DrawImage(image, rectDes, rectSrc, GraphicsUnit.Pixel);
        }
    }
}
