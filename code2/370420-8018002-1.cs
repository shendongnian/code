    PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(100, 50),
                Location = new Point(14, 17),
                Image = Image.FromFile(@"..\Image\1.jpg")
            };
    p.Controls.Add(picture);
