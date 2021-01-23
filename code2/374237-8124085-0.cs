    const int width = 100;
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        Font font = new Font(txt.Font.Name, txt.Font.Size);
    
        Size s = TextRenderer.MeasureText(txt.Text, font);
        if (s.Width > width)
        {
            txt.Width = s.Width;
        }
    }
