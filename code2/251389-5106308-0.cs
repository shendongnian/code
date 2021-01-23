    string pattern1 = @"^TE(?<DATE>[0-9]{8})(?<NEXT1>.{2})(?<NEXT2>.{2})";
    string pattern2 = @"^RE(?<DATE>[0-9]{8})(?<NEXT1>.{3})(?<NEXT2>.{2})";
    string pattern3 = @"^CE(?<DATE>[0-9]{8})(?<NEXT1>.{4})(?<NEXT2>.{2})";
    Regex Regex1 = new Regex(pattern1);
    Regex Regex2 = new Regex(pattern2);
    Regex Regex3 = new Regex(pattern3);
    StringBuilder FirstStringBuilder = new StringBuilder();
    StringBuilder SecondStringBuilder = new StringBuilder();
    StringBuilder ThirdStringBuilder = new StringBuilder();
    string Line = "";
    Match LineMatch;
    FileInfo myFile = new FileInfo("yourFile.txt");
    using (StreamReader s = new StreamReader(f.FullName))
    {
        while (s.Peek() != -1)
        {
            Line = s.ReadLine();
            LineMatch = Regex1.Match(Line);
            if (LineMatch.Success)
            {
                //Write this line to a new file
            }
            LineMatch = Regex2.Match(Line);
            if (LineMatch.Success)
            {
                //Write this line to a new file
            }
            LineMatch = Regex3.Match(Line);
            if (LineMatch.Success)
            {
                //Write this line to a new file
            }
        }
    }
