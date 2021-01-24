    private readonly Size _innerMargin = new Size(183, 55); // Estimated
    private readonly Size _outerMargin;
    private readonly float _aspectRatio;
    public Form1()
    {
        InitializeComponent();
        _outerMargin = Size - chart1.Size;
        Size innerSize = chart1.Size - _innerMargin;
        _aspectRatio = (float)innerSize.Width / innerSize.Height;
    }
