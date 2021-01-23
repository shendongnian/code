    Bitmap GetBitmap(byte[] buf)
    {
        Int16 width = BitConverter.ToInt16(buf, 18);
        Int16 height = BitConverter.ToInt16(buf, 22);
        Bitmap bitmap = new Bitmap(width, height);
        int imageSize = width * height * 4;
        int headerSize = BitConverter.ToInt16(buf, 10);
        System.Diagnostics.Debug.Assert(imageSize == buf.Length - headerSize);
        int offset = headerSize;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                bitmap.SetPixel(x, height - y - 1, Color.FromArgb(buf[offset + 3], buf[offset], buf[offset + 1], buf[offset + 2]));
                offset += 4;
            }
        }
        return bitmap;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        using (FileStream f = File.OpenRead("base64.txt"))
        {
            byte[] buf = Convert.FromBase64String(new StreamReader(f).ReadToEnd());
            Bitmap bmp = GetBitmap(buf);
            this.ClientSize = new Size(bmp.Width, bmp.Height);
            this.BackgroundImage = bmp;
        }
    }
