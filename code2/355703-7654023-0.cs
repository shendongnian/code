    public void LoadTexture(GraphicsDevice gfx, ContentManager content, string filename, float duration = -1f)
    {
        this.gfx = gfx;
        this.filename = filename;
        this.duration = duration;
        Thread thread = new Thread(GetWebScreenshot);
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
    }
    public void GetWebScreenshot()
    {
        this.web = new WebBrowser();
        this.web.Size = new Size(gfx.Viewport.Width, gfx.Viewport.Height);
        this.web.Url = new Uri(this.filename);
        this.web.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
        Application.Run(); // Starts pumping the message queue (and keeps the thread running)
    }
    void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        Bitmap bitmap = new Bitmap(this.gfx.Viewport.Width, this.gfx.Viewport.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        this.web.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height));
        this.texture = HTMLTextureFactoryMachine.BitmapToTexture2D(this.gfx, bitmap);
        Application.ExitThread(); // Exits the thread
    }
