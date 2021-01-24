    // from 8am (8) to midnight (23).
    if (DateTime.Now.Hour >= 8)
    {
        TextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
    }
    else
    {
        // from midnight (0) to 8am (8).
        TextBox1.BackColor = System.Drawing.Color.AliceBlue;
    }
