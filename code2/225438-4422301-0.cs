    String PreString = "HelloWorld";
    System.Text.StringBuilder SB = new System.Text.StringBuilder();
    foreach (Char C in PreString)
    {
        if (Char.IsUpper(C))
            SB.Append(' ');
        SB.Append(C);
    }
    Response.Write(SB.ToString());
