    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpPostedFile pf = FileUpload1.PostedFile;
        System.Drawing.Image bm = System.Drawing.Image.FromStream(pf.InputStream);
        bm = ResizeBitmap((Bitmap) bm, 100, 100); /// new width, height
        bm.Save(Path.Combine(YOURUPLOADPATH, pf.FileName);
    }
    private Bitmap ResizeBitmap(Bitmap b, int nWidth, int nHeight)
    {
        Bitmap result = new Bitmap(nWidth, nHeight);
        using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
            g.DrawImage(b, 0, 0, nWidth, nHeight);
        return result;
    }
