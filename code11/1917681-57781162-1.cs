    // hours go from 0 to 23.
    // from 8am (8) to midnight. at midnight we go back to 0 so we go to the 'else' block.
    if (DateTime.Now.Hour >= 8)
    {
        TextBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
    }
    else
    {
        // from midnight (0) to 8am (8).
        TextBox1.BackColor = System.Drawing.Color.AliceBlue;
    }
