    for (int i = 0; i < theArray.Length; i++)
    {
        Left = 0;
        Right = 0;
        if (i > 0)
        {
            Left = theArray[i-1];
        }
        if (i < theArray.Length - 1)
        {
            Right = theArray[i+1];
        }
    
        calc = Left + Right;
        output2.Text += calc + ", ";
    }
