    readonly Region _client;
    public Form1()
    {
        InitializeComponent();
        // calculate smaller inner region using same method
        _client = Region.FromHrgn(CreateRoundRectRgn(1, 1, Width - 1, Height - 1, 20, 20));
        Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        // FillRectangle is faster than FillRegion for drawing outer bigger region
        // and it's actually not needed, you can simply set form BackColor to wanted border color
        // e.Graphics.FillRectangle(Brushes.Red, ClientRectangle);
        e.Graphics.FillRegion(Brushes.White, _client);
    }
