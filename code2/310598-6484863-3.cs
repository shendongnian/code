    private void Form1_Load(object sender, EventArgs e)
    {
       MoveCursor ();
    }
    private void Form1_Resized(object sender, EventArgs e)
    {
       MoveCursor ();
    }
    private void Form1_LocationChanged(object sender, EventArgs e)
    {
       MoveCursor ();
    }
    private void MoveCursor()
    {
       Cursor.Clip = Bounds
       this.Capture = true;
    }
