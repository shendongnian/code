    var txt1 = textBox1.Lines.Where(a => !string.IsNullOrEmpty(a)).ToArray();
    var txt2 = textBox2.Lines.Where(b => !string.IsNullOrEmpty(b)).ToArray();
    var txt3 = "";
    
    for(int i = 0; i < txt1.Length; i++)
    {
        if (i < txt2.Length)
            txt3 += $"{txt1[i]}:{txt2[2]}{Environment.NewLine}";
    }
    
    textBox3.Text = txt3;
Good luck.
