    for (int i = 0; i < Text1.TextLength; i++)
    {
        Text1.SelectionStart = i;
        Text1.SelectionLength = 1;
        if (Text1.SelectionCharOffset > 0)
        {
            ...
        }
    }
