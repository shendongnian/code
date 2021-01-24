    // midnight (0) to 1am OR 8am to midnight.
    if (DateTime.Now.Hour == 0 || DateTime.Now.Hour >= 8)
    {
        TextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
    }
    else
    {
        // from 1am (1) to 8am (8).
        TextBox1.BackColor = System.Drawing.Color.AliceBlue;
    }
