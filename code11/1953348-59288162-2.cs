     // now picture is a private field, visible within th class
     //TODO: do not forget to Dispose it
     private PictureBox picture;
     private void Button1_Click(object sender, EventArgs e)
     {
        if (picture != null) // already created
          return;
        var picture = new PictureBox
        {
            Name     = "pictureBox",
            Size     = new Size(20, 20),
            Location = new System.Drawing.Point(x, y),
            Image    = image1,
            Parent   = this, // instead of this.Controls.Add(picture);
        };
        timer1.Enabled = true;
    }
  
    private void Timer1_Tick(object sender, EventArgs e)
    {
        //redefine pictureBox position.
        x = x - 50;
        if (picture != null) // if created, move it
          picture.Location = new System.Drawing.Point(x, y); 
    }
