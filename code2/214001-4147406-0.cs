    private void Form1_Load(object sender, EventArgs e)
    {
        // textBox1 is the control on your form.
        // 1000 is the total interval between flashes
        // Color.LightBlue is the flash color
        // 10 is the number of flashes before the thread quits.
        Flash(textBox1, 1000,Color.LightBlue,10);
    }
    
    public void Flash(TextBox textBox, int interval, Color color, int flashes)
    {
        new Thread(() => FlashInternal(textBox, interval, color, flashes)).Start();
    }
    
    private delegate void UpdateTextboxDelegate(TextBox textBox, Color originalColor);
    public void UpdateTextbox(TextBox textBox, Color color)
    {
        if (textBox.InvokeRequired)
        {
            this.Invoke(new UpdateTextboxDelegate(UpdateTextbox), new object[] { textBox, color });
        }
        textBox.BackColor = color;
    }
    
    private void FlashInternal(TextBox textBox, int interval, Color flashColor, int flashes)
    {
        Color original = textBox.BackColor;
        for (int i = 0; i < flashes; i++)
        {
    
            UpdateTextbox(textBox, flashColor);
            Thread.Sleep(interval/2);
            UpdateTextbox(textBox, original);
            Thread.Sleep(interval/2);
        }
    }
