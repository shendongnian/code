    PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(100, 50),
                Location = new Point(14, 17),
                Image = Image.FromFile(@"c:\Images\test.jpg")
            };
    p.Controls.Add(picture);
