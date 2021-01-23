    for(int r = 0; r <= invaderrow-1; r++)
        {
            for( int c = 0; c<=invadercol-1; c++)
            {
                objsp.invader[c] = new PictureBox();
                objsp.invader[c].Image= pictureBox2.Image;
                objsp.invader[c].Image = Resized(pictureBox2.Image, 2);
                objsp.invader[c].BackColor = Color.Transparent;
                objsp.invader[c].Location= new Point((c * 100) + 10, 10 + r * 50);
                this.Controls.Add(objsp.invader[c]);
            }
        }
