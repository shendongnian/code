    using (Image imgNew = Clipboard.GetImage()) //Getting the image in clipboard
    {
        if (imgNew != null)
        {
            Bitmap btnImg = new Bitmap(imgNew, 150, 100);
            using (Graphics g = Graphics.FromImage((Image)btnImg))
                g.DrawImage(btnImg, 0, 0, 150, 100);
            pictureBox1.Image = btnImg;
        }
    }
