    private void watermark_btn_Click(object sender, EventArgs e)
    {
        string watermarkText = "ShowThisWatermark";
        using (Font font = new Font("Times New Roman", (float)25, FontStyle.Regular))
        using (SolidBrush brush = new SolidBrush(Color.Red))
        foreach (string file in Directory.GetFiles(directory_txt.Text))
        {
            try
            {
                Bitmap b = new Bitmap(file);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    SizeF measuredSize = g.MeasureString(watermarkText, font);
                    // Use this to watermark the bottom-left corner
                    g.DrawString(watermarkText, font, brush, 0, b.Height - measuredSize.Height);
                    // Use this to watermark the bottom-right corner
                    g.DrawString(watermarkText, font, brush, b.Width - measuredSize.Width, b.Height - measuredSize.Height);
                }
                b.Save(Path.GetFileNameWithoutExtension(file) + "_stamped" + Path.GetExtension(file));
            }
            catch
            {
                continue;
            }
        }
    }
