        int width = 20, height = 41;
        byte[] grayscale_image = {0, 0, 0, ...};
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height);
        int x = 0;
        int y = 0;
        foreach (int i in grayscale_image)
        {
            bitmap.SetPixel(x, y, System.Drawing.Color.FromArgb(i, i, i));
            x++;
            if (x >= 41)
            {
                x = 0;
                y++;
            }
        }
        bitmap.Save("output.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
