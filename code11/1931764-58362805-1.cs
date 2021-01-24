    FontStyle style;
    if (checkBox1.Checked)
    {
        style = style | FontStyle.Bold;
    }
    if (checkBox2.Checked)
    {
        style = style | FontStyle.Italic;
    }
    
    textBox1.Font = new Font(style);
