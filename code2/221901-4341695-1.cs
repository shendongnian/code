    string[] arLines;
    arLines = RTB1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
    for( int i = 0; i < arLines.Length; ++i )
    {
        RTB2.Text = arLines[i];
    }
