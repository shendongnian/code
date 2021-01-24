    public static Random random = new Random();
    public static Image[] images;
    // Call this once at program start.
    public static LoadImages()
    {
        string[] files = Directory.GetFiles(Application.StartupPath, "*.png");
        images = new Image[files.Length];
        for (int i = 0; i < files.Length; i++) {
            images[i] = Image.FromFile(files[i]);
        }
    }
    public static void Draw(System.Drawing.Graphics g, int x, int y)
    {
        try
        {
            int index = random.Next(0, images.Length);
            g.DrawImage(images[index], x, y, 40, 40);
        }
        catch(Exception ee) {
            MessageBox.Show("Error! " +ee.Message + " " + ee.Source + " " + ee.HelpLink, "Oh No",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        cookiecount++;
    }
