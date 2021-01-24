    private void saveBtn_Click(object sender, EventArgs e)
    {
        Size sz = pictureBox1.ClientSize;
        using (Bitmap bmp = new Bitmap(sz.Width, sz.Height))
        {
            Color old = wedgeCallout1.BackColor;
            wedgeCallout1.BackColor = Color.Transparent;
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
            bmp.Save(filename, ImageFormat.Png);
            wedgeCallout1.BackColor = old;
        }
    }
