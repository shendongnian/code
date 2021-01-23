    public Form1() 
    {
      InitializeComponent();
      button1.Tag = pictureBox1;
      button1.Click += btnT_Click;
      // etc..
    }
    private void btnT_Click(object sender, EventArgs e)
    {
      var btn = (Button)sender;
      cropPict((PictureBox)bnt.Tag, CropSide.Top);
    }
