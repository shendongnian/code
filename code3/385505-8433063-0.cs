    private void btnNext_Click(object sender, EventArgs e)
    {
       if(index < images.Count) {
          index++;
          pictureBox1.Image = images[index];
       }
    }
    
    private void btnPrevious_Click(object sender, EventArgs e)
    {
       if(index > 0)
       {
          index--;
          pictureBox1.Image = images[index];
       }
    }
