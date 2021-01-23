    private void Form1_Load(object sender, EventArgs e)
    {
        this.textBox1.GotFocus += new System.EventHandler(this.AllTextBoxes_GotFocus);
        this.textBox2.GotFocus += new System.EventHandler(this.AllTextBoxes_GotFocus);
    
        this.textBox1.LostFocus += new System.EventHandler(this.AllTextBoxes_LostFocus);
        this.textBox2.LostFocus += new System.EventHandler(this.AllTextBoxes_LostFocus);
    }
    
    private void AllTextBoxes_GotFocus(object sender, System.EventArgs e)
    {
        if (sender is TextBox)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
    }
    
    private void AllTextBoxes_LostFocus(object sender, System.EventArgs e)
    {
        if (sender is TextBox)
        {
            ((TextBox)sender).BackColor = Color.LightSteelBlue;
        }
    }
