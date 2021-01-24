    public Form1()
    {
        InitializeComponent();
    }
    [DllImport("user32.dll", EntryPoint = "ShowCursor", CharSet = CharSet.Auto)]
    public extern static void ShowCursor(int status);
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        Point p1 = MousePosition;
        // Get the mouse position in the form
        Point p2 = PointToClient(p1);
        // Reset picturebox location
        pictureBox1.Location = new Point(p2.X - pictureBox1.Width /2 , p2.Y - pictureBox1.Height /2);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        // Load picture
        pictureBox1.Image = Image.FromFile(@"D:\pic123\target.png");
        // Hide cursor
        ShowCursor(0);
    }
