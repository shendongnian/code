    // the midnight hour (babe) OR 8am to midnight.
    if (DateTime.Now.Hour == 0 || DateTime.Now.Hour >= 8)
    {
        TextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
    }
    else
    {
        // from 1am (1) up to 8am.
        TextBox1.BackColor = System.Drawing.Color.AliceBlue;
    }
