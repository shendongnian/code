    private void Form1_Load(object sender, EventArgs e)
    {
        var pb = new PictureBox();
        using (var stream = new MemoryStream(GetImageData(1)))
        {
            pb.Image = Image.FromStream(stream);
        }
        Controls.Add(pb);
    }
