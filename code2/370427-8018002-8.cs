    PictureBox picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(100, 50),
                Location = new Point(14, 17),
                ImageLocation = @"c:\Images\test.jpg",
                SizeMode = PictureBoxSizeMode.CenterImage
            };
    p.Controls.Add(picture);
