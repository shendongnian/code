    private void Form1_Resize_1(object sender, EventArgs e)
    {
        textBox1.Text = this.Width.ToString();
        textBox2.Text = (this.Height - 200).ToString();
        int iTop = canvas21.Top;
        int iLeft = canvas21.Left;
        // - 200 - iTop keeps it 200 from the bottom, -iLeft keeps i stuck to right
        canvas21.Size = new System.Drawing.Size(this.Width -iLeft, this.Height-200 -iTop);
        canvas21.Left = iLeft;   // move back
        canvas21.Top = iTop;   // move back
        canvas21.Invalidate();
    }
