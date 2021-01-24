        Regex tags = new Regex(@"<color=#.*?>|<\/color>");
        MatchCollection matches = tags.Matches(c);
        bool hasStarted = false;
        int innerTags = 0;
        const string tempStart = "Â¬Â¬Â¬Â¬Â¬Â¬Â¬Â";
        const string tempEnd = "Â~Â~Â~Â~";
        foreach (Match match in matches)
        {
            if (match.Value.Contains("<color=#"))
            {
                if (hasStarted)
                {
                    var cBuilder = new StringBuilder(c);
                    cBuilder.Remove(match.Index, match.Length);
                    cBuilder.Insert(match.Index, tempStart);
                    c = cBuilder.ToString();
                    innerTags++;
                }
                else
                {
                    hasStarted = true;
                }
            }
            else if (match.Value.Equals("</color>"))
            {
                if (innerTags > 0)
                {
                    var cBuilder = new StringBuilder(c);
                    cBuilder.Remove(match.Index, match.Length);
                    cBuilder.Insert(match.Index, tempEnd);
                    c = cBuilder.ToString();
                    innerTags--;
                }
                else if (innerTags <= 0)
                {
                    hasStarted = false;
                }
            }
        }
        c = c.Replace(tempStart, string.Empty);
        c = c.Replace(tempEnd, string.Empty);
