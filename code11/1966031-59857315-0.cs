    bool newImageInstalled = true;
    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.WaitOnLoad = true;
    }
    private void PictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (!newImageInstalled)
        {
            newImageInstalled = true;
            BeginInvoke(new Action(() =>
            {
                //Capturing the new image
                using (var bm = new Bitmap(pictureBox1.ClientSize.Width, 
                    pictureBox1.ClientSize.Height))
                {
                    pictureBox1.DrawToBitmap(bm, pictureBox1.ClientRectangle);
                    var tempFile = System.IO.Path.GetTempFileName() + ".png";
                    bm.Save(tempFile, System.Drawing.Imaging.ImageFormat.Png);
                    System.Diagnostics.Process.Start(tempFile);
                }
            }));
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        newImageInstalled = false;
        pictureBox1.ImageLocation = 
        "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png";
    }
    private void button2_Click(object sender, EventArgs e)
    {
        newImageInstalled = false;
        pictureBox1.Image = null;
    }
