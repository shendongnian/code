    public void Form1_Load(Object sender, EventArgs e) 
    {
        ... // Other initialization code
        maskedTextBox1.Mask = "00/00/0000";
        maskedTextBox1.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected)
    }
    
    void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
    {
        toolTip1.ToolTipTitle = "Invalid Input";
        toolTip1.Show("We're sorry, but only digits (0-9) are allowed in dates.", maskedTextBox1, maskedTextBox1.Location, 5000);
    }
