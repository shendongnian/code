    private void Rulercompass_Paint(object sender, PaintEventArgs e)
    {
        Bitmap bit_map = new Bitmap(img.Width, img.Height);
        using (Graphics gfx = Graphics.FromImage(bit_map))
        {
            gfx.TranslateTransform(bit_map.Width / 2, bit_map.Height / 2);
            gfx.RotateTransform(angle);
            gfx.TranslateTransform(-bit_map.Width / 2, -bit_map.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                
            gfx.DrawImage(img, 0, 0);
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.DrawImage(bit_map, -bit_map.Width / 2, -bit_map.Height / 2);
        }
        bit_map.Dispose();// after using dispose this is what was missing
    }
