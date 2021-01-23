    private void Form1_Resize_1(object sender, EventArgs e)
    {
        textBox1.Text = this.Width.ToString();
        textBox2.Text = (this.Height - 200).ToString();
        canvas21.Size = new System.Drawing.Size(this.ClientSize.Width,  this.ClientSize.Height - canvas21.Top - 15);
        canvas21.Invalidate();
    }
