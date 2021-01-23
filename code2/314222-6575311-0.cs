    private void Form1_Resize(object sender, EventArgs e)
    {
        label1.Size = new Size(this.ClientSize.Width, Convert.ToInt32(0.4 * this.ClientSize.Height));
        label1.Location = new Point(0, Convert.ToInt32(0.6 * this.ClientSize.Height));
    }
