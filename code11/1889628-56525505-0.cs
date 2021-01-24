    private int state = 1;
    public Exam5()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        timer1.Enabled = true;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        string selectedImage;
        
        state++;
        
        if (state > 3) state = 1;
        
        switch (state)
        {
            case 1: 
                selectedImage = "Scissor.jpg";
                break;
                
            case 1: 
                selectedImage = "Stone.jpg";
                break;
                
            case 1: 
                selectedImage = "Paper.jpg";
                break;
        }
        
        pictureBox1.Image = new Bitmap(selectedImage);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        timer1.Enabled = false;
        pictureBox2.Image = new Bitmap("Scissor.jpg");
        if (state == 1) 
            label1.Text = "Tie";
        else if (state == 2) 
            label1.Text = "You lose";
        else 
            label1.Text = "You win";
    }
