    // In initializecomponent()
    button1.Click += button1_Click;
    // The click handler 
    private void button1_Click(object sender, EventArgs e)
    {
       if (open.ShowDialog() == DialogResult.OK)
       {          
          dir.Text = open.FileName.ToString();   
          image = new Bitmap(dir.Text);        
          pictureBox1.Image = image;
       }
    }
