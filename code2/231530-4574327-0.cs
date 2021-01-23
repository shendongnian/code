    public Image Image
    {
        get { return pictureBox1.Image; }
        set { 
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = value; 
        }
    }
