    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        int originalWidth = this.pictureBox1.Image.Width;
        int originalHeight = this.pictureBox1.Image.Height;
        PropertyInfo rectangleProperty = this.pictureBox1.GetType().GetProperty("ImageRectangle", BindingFlags.Instance | BindingFlags.NonPublic);
        Rectangle rectangle = (Rectangle)rectangleProperty.GetValue(this.pictureBox1, null);
        int currentWidth = rectangle.Width;
        int currentHeight = rectangle.Height;
        double rate = (double)currentHeight / (double)originalHeight;
        int black_left_width = (currentWidth == this.pictureBox1.Width) ? 0 : (this.pictureBox1.Width - currentWidth) / 2;
        int black_top_height = (currentHeight == this.pictureBox1.Height) ? 0 : (this.pictureBox1.Height - currentHeight) / 2;
        int zoom_x = e.X - black_left_width;
        int zoom_y = e.Y - black_top_height;
        // Get original position
        double original_x = (double)zoom_x / rate;
        double original_y = (double)zoom_y / rate;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Mouse coordinates in original image\n{0}/{1}(X/Y)\r\n", original_x, original_y);
        this.label1.Text = sb.ToString();
        try
        {
            // Get RGB of pixel
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Color c = bitmap.GetPixel((int)original_x, (int)original_y);
            label2.Text = string.Format("{0},{1},{2}", c.R, c.G, c.B);
        }
        catch { }
    }
