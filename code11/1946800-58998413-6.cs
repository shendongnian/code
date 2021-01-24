    void createIcon(IconDefinition iconDefinition)
    {
        PictureBox pictureBox = new PictureBox()
        {
            Name = iconDefinition.Name,
            Size = new Size(iconDefinition.Width, iconDefinition.Height),
            Location = new Point(iconDefinition.X, iconDefinition.Y),
            Image = Icon.ExtractAssociatedIcon(iconDefinition.Path).ToBitmap(),
            SizeMode = PictureBoxSizeMode.Zoom
        };
        pictureBox.Click += myClickHandler;
        Form1Singleton.FormVerweis.pictureBox1.Controls.Add(pictureBox);
    }
