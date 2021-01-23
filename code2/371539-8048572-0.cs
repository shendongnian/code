    public Form1()
    {
        InitializeComponent();
        this.textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
    }
    void textBox1_TextChanged(object sender, EventArgs e)
    {
        System.Drawing.SizeF mySize = new System.Drawing.SizeF();
        // Use the textbox font
        System.Drawing.Font myFont = textBox1.Font;
        using (Graphics g = this.CreateGraphics())
        {
            // Get the size given the string and the font
            mySize = g.MeasureString(textBox1.Text, myFont);
        }
        // Resize the textbox 
        this.textBox1.Width = (int)Math.Round(mySize.Width, 0);
    }
}
