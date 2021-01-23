    List<Image> images = new List<Image>();
    
    // assign images.  images.Add(...
    private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = images[imgIndex++];
        }
