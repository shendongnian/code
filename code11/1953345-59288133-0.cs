    PictureBox picture;
    private void Button1_Click(object sender, EventArgs e)
        {
            picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(20, 20),
                Location = new System.Drawing.Point(x, y),
                Image = image1,
    
            };
            this.Controls.Add(picture);
            timer1.Enabled = true;
    
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //redefine pictureBox position.
            x = x - 50;
            if(picture != null)
                picture.Location = new System.Drawing.Point(x, y);
        }
