    string WorkingSolutionForOneLine(string line)
    {
        string sTemp = line.Substring(0, 30);
        sTemp = sTemp.Replace(" @A ", "");
        sTemp = sTemp.Replace("@A ", "");
        sTemp = sTemp.Replace(" @A", "");
        sTemp = sTemp.Replace("@A", "");
        sTemp = sTemp.Replace(" @B ", "");
        sTemp = sTemp.Replace("@B ", "");
        sTemp = sTemp.Replace(" @B", "");
        sTemp = sTemp.Replace("@B", "");
        int numberOfLeak = 30 - sTemp.Length;
        var x = 30 + numberOfLeak;
        if (line.Length > x)
        {
            line = line.Insert(x, Environment.NewLine);
        }
        return line;
    }
