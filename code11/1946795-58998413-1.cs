    void createIcon(IconDefinition iconDefinition) => Form1Singleton.FormVerweis.pictureBox1.Controls.Add(new PictureBox()
    {
        Name = iconDefinition.Name,
        Size = new Size(iconDefinition.Width, iconDefinition.Height),
        Location = new Point(iconDefinition.X, iconDefinition.Y),
        Image = Icon.ExtractAssociatedIcon(iconDefinition.Path).ToBitmap(),
        SizeMode = PictureBoxSizeMode.Zoom
    });
