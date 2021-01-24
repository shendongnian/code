    void loadFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            pictureBox1.Size = panel1.ClientSize;
            pictureBox1.Location = Point.Empty;
            pictureBox1.Image = Image.FromFile(fileName);
            pictureBox2.Image = Image.FromFile(fileName);
            pictureBox2.Location = Point.Empty;
        }
        Size csz = pictureBox1.ClientSize;
        Size isz = pictureBox1.Image.Size;
        float iar = 1f * isz.Width / isz.Height;
        float car = 1f * csz.Width / csz.Height;
        if (iar < car)
        {
            pictureBox1.ClientSize = new Size((int)(pictureBox1.ClientSize.Height * iar), 
                                              pictureBox1.ClientSize.Height);
        }
        else if (iar > car)
        {
            pictureBox1.ClientSize = new Size((pictureBox1.ClientSize.Width,
                                              (int)(pictureBox1.ClientSize.Width / iar));
        }
    }
